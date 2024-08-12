using System.Text.Json;
using TreeNodeException.Api.Exceptions;
using TreeNodeException.Api.Models;

namespace TreeNodeException.Api.Middlewares;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex)
        {
            var context = httpContext.RequestServices.GetRequiredService<ApplicationDbContext>();
            await HandleExceptionAsync(httpContext, ex, context);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception, ApplicationDbContext dbContext)
    {
        var exceptionLog = new ExceptionLog
        {
            Timestamp = DateTime.UtcNow,
            RequestQueryParams = JsonSerializer.Serialize(context.Request.Query),
            RequestBody = await new StreamReader(context.Request.Body).ReadToEndAsync(),
            StackTrace = exception.StackTrace,
            ExceptionType = exception.GetType().Name,
            ExceptionMessage = exception.Message
        };

        dbContext.ExceptionLogs.Add(exceptionLog);
        await dbContext.SaveChangesAsync();

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = StatusCodes.Status500InternalServerError;

        var result = exception is SecureException
            ? new { type = "Secure", id = exceptionLog.EventId, data = new { message = exception.Message } }
            : new { type = "Exception", id = exceptionLog.EventId, data = new { message = $"Internal server error ID = {exceptionLog.EventId}" } };

        await context.Response.WriteAsync(JsonSerializer.Serialize(result));
    }
}
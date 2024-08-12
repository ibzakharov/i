namespace TreeNodeException.Api.Middlewares.Extensions;

public static class MiddlewareExtensions
{
    public static IApplicationBuilder UseException(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ExceptionMiddleware>();
    }
    
    public static IApplicationBuilder UseRedirectToSwagger(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<RedirectToSwaggerMiddleware>();
    }
}
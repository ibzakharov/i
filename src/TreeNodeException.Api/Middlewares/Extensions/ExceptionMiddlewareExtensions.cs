namespace TreeNodeException.Api.Middlewares.Extensions;

public static class ExceptionMiddlewareExtensions
{
    public static IApplicationBuilder UseException(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ExceptionMiddleware>();
    }
}
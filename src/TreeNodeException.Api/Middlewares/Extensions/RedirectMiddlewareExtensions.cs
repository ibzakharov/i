namespace TreeNodeException.Api.Middlewares.Extensions;

public static class RedirectMiddlewareExtensions
{
    public static IApplicationBuilder UseRedirect(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<RedirectMiddleware>();
    }
}
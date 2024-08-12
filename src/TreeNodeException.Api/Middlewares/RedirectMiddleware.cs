namespace TreeNodeException.Api.Middlewares;

public class RedirectMiddleware
{
    private readonly RequestDelegate _next;

    public RedirectMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if (context.Request.Path.Equals("/create"))
        {
            // Выполнение редиректа на новую страницу
            context.Response.Redirect("/api/tree", permanent: true);
            return; 
        }
        
        await _next(context);
    }
}
using System.Text;

namespace GameWebApplication.Middlewares;

public class BasicAuthMiddleware(RequestDelegate next)
{
    private const string AuthHeaderName = "Authorization";
    private const string Username = "admin";
    private const string Password = "admin";

    public async Task InvokeAsync(HttpContext context)
    {
        if (!context.Request.Headers.TryGetValue(AuthHeaderName, out var value))
        {
            context.Response.StatusCode = 401;
            await context.Response.WriteAsync("Authorization header missing");
            return;
        }

        var authHeader = value.ToString();
        if (!authHeader.StartsWith("Basic ", StringComparison.OrdinalIgnoreCase))
        {
            context.Response.StatusCode = 401;
            await context.Response.WriteAsync("Invalid authorization header");
            return;
        }

        var encodedCredentials = authHeader["Basic ".Length..].Trim();
        var credentials = Encoding.UTF8.GetString(Convert.FromBase64String(encodedCredentials)).Split(':');

        if (credentials is not [Username, Password])
        {
            context.Response.StatusCode = 401;
            await context.Response.WriteAsync("Invalid username or password");
            return;
        }

        await next(context);
    }
}
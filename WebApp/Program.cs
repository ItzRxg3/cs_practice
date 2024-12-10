using Microsoft.AspNetCore.Authentication;
using GameWebApplication.Auth;
using GameWebApplication.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Auth token
/*builder.Services.AddAuthentication("BasicAuthentication")
    .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);
builder.Services.AddAuthorization();*/

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.UseRouting();

//app.UseAuthentication();
//app.UseAuthorization();

app.UseMiddleware<BasicAuthMiddleware>();

app.MapControllers();

app.MapGet("/", () => "Hello World!");

await app.RunAsync();
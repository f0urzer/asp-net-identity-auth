using Auth.API.Entities;
using Microsoft.AspNetCore.Identity;
using System.Text.Json;

namespace Auth.API.Middlewares
{
    public sealed class LoginMiddleware(RequestDelegate _next, IServiceScopeFactory _scopeFactory)
    {
        public async Task InvokeAsync(HttpContext context, AuthDbContext dbContext)
        {
            if (context.Request.Path.Equals("/login", StringComparison.OrdinalIgnoreCase) &&
                context.Request.Method == HttpMethods.Post)
            {
                using var scope = _scopeFactory.CreateScope();
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();

                var login = new LoginHistory
                {
                    UserId = await GetUserId(context, userManager),
                    LoginDate = DateTime.UtcNow,
                    IpAddress = context.Connection.RemoteIpAddress!.ToString()
                };
                Console.WriteLine(context.Connection.RemoteIpAddress);
                dbContext.LoginHistories.Add(login);
                await dbContext.SaveChangesAsync();
            }

            await _next(context);
        }

        private async Task<string> GetUserId(HttpContext context, UserManager<User> manager)
        {
            string username = await ExtractUsernameFromBodyAsync(context.Request);
            var user = await manager.FindByNameAsync(username!);
            return user!.Id;
        }

        private async Task<string> ExtractUsernameFromBodyAsync(HttpRequest request)
        {
            request.EnableBuffering();
            
            using var reader = new StreamReader(request.Body);
            var body = await reader.ReadToEndAsync();
            request.Body.Position = 0;
            
            var json = JsonDocument.Parse(body);
            
            return json.RootElement.GetProperty("email").GetString()!;
        }
    }
}

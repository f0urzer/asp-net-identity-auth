using Auth.API.Entities;
using System.Text.Json;

namespace Auth.API.Middlewares
{
    public sealed class LogMiddleware(RequestDelegate next)
    {
        private readonly string _logFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Logs", $"request-log-{DateTime.UtcNow:yyyy-MM-dd}.txt");

        public async Task InvokeAsync(HttpContext context)
        {
            var log = new Dictionary<string, object>
            {
                ["Timestamp"] = DateTime.UtcNow.ToString("o"),
                ["Method"] = context.Request.Method,
                ["Path"] = context.Request.Path,
                ["Query"] = context.Request.QueryString.ToString()
            };

            try
            {
                var username = await GetUsernameFromBody(context.Request);
                if (!string.IsNullOrWhiteSpace(username))
                    log["User"] = username;
            }
            catch
            {
                log["User"] = "COULD NOT PARSE BODY";
            }

            await WriteLogToFile(log);

            await next(context);
        }

        private async Task<string> GetUsernameFromBody(HttpRequest request)
        {
            request.EnableBuffering();

            using var reader = new StreamReader(request.Body, leaveOpen: true);
            var body = await reader.ReadToEndAsync();
            request.Body.Position = 0;

            var json = JsonDocument.Parse(body);

            return json.RootElement.TryGetProperty("email", out var emailProp)
                ? emailProp.GetString() ?? string.Empty
                : string.Empty;
        }

        private async Task WriteLogToFile(Dictionary<string, object> data)
        {
            try
            {
                var logDirectory = Path.GetDirectoryName(_logFilePath);
                if (!Directory.Exists(logDirectory))
                    Directory.CreateDirectory(logDirectory!);

                var logJson = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });

                await File.AppendAllTextAsync(_logFilePath, logJson + Environment.NewLine);
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR WHILE WRITING THE LOG: " + ex.Message);
            }
        }
    }
}

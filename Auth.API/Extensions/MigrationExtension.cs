using Auth.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Auth.API.Extensions
{
    public static class MigrationExtension
    {
        public static void ApplyMigrations(this IApplicationBuilder application)
        {
            using IServiceScope scope = application.ApplicationServices.CreateScope();

            using AuthDbContext context = scope.ServiceProvider.GetRequiredService<AuthDbContext>();

            context.Database.Migrate();
        }
    }
}
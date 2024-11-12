using Auth.API.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Auth.API.Extensions
{
    public static class ServiceExtension
    {
        public static void AddIdentity(this IServiceCollection services)
        {
            services.AddAuthentication()
                    .AddCookie(IdentityConstants.ApplicationScheme)
                    .AddBearerToken(IdentityConstants.BearerScheme);

            services.AddAuthorization();

            services.AddIdentityCore<User>()
                    .AddEntityFrameworkStores<AuthDbContext>()
                    .AddApiEndpoints();
        }

        public static void AddDbConnection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AuthDbContext>(opt => opt.UseNpgsql(configuration.GetConnectionString("DbConString"))); 
        }
    }
}

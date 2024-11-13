using Auth.API.Entities;
using Auth.API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;

namespace Auth.API.Extensions
{
    public static class ServiceRegistration
    {
        public static void AddIdentity(this IServiceCollection services)
        {
            services.AddAuthentication(options => {
                                       options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                                       options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;})
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

        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddTransient<IEmailSender, EmailSender>();
        }
    }
}

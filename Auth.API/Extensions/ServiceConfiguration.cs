using Auth.API.Configs;
using Microsoft.AspNetCore.Identity;

namespace Auth.API.Extensions
{
    public static class ServiceConfiguration
    {
        public static void ConfigureIdentity(this IServiceCollection services)
        {
            services.Configure<IdentityOptions>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.Stores.ProtectPersonalData = true;
                options.SignIn.RequireConfirmedEmail = true;
                options.SignIn.RequireConfirmedAccount = true;
            });
        }

        public static void ConfigureBinding(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<SmtpConfig>(options => configuration.GetSection("Smtp").Bind(options));
        }
    }
}

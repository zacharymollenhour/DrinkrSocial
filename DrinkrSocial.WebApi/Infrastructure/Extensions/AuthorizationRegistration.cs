using DrinkrSocial.Persistence.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace DrinkrSocial.WebApi.Infrastructure.Extensions
{
    public static class AuthorizationRegistration
    {
        public static void ConfigureAuth(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, opts =>
            {
                var jwtSettings = configuration.GetSection("JWTSettings").Get<JWTSettings>();
            });
        }

    }
}

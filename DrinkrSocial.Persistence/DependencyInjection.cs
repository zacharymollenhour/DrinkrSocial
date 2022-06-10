
using DrinkrSocial.Application.Interfaces;

using DrinkrSocial.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DrinkrSocial.Persistence.Settings;
using DrinkrSocial.Application.Interfaces.Repositories;
using DrinkrSocial.Persistence.Repositories;
using DrinkrSocial.Application.Interfaces.Services;
using DrinkrSocial.Persistence.Services;
using EasyCaching.Core.Configurations;

namespace DrinkrSocial.Persistence
{
    public static class DependencyInjection
    {
        public static void AddInfrastructreServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DBConnection"));
            });

            services.Configure<JWTSettings>(configuration.GetSection("JWTSettings"));
            services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
            services.Configure<CacheSettings>(configuration.GetSection("CacheSettings"));

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITokenRefreshRepository, TokenRefreshRepository>();
            services.AddScoped<IUserRoleRepository, UserRoleRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<ITokenService, TokenService>();

            services.AddScoped<ITavernRepository, TavernRepository>();



            var cacheSettings = configuration.GetSection("CacheSettings").Get<CacheSettings>();

            if (cacheSettings.PreferRedis)
            {
                services.AddEasyCaching(option =>
                {
                    option.WithJson();
                    option.UseRedis(config =>
                    {
                        config.DBConfig.Endpoints.Add(new ServerEndPoint(cacheSettings.RedisURL, cacheSettings.RedisPort));
                    }, "json");
                });
            }
            else
            {
                services.AddEasyCaching(option =>
                {
                    option.UseInMemory();
                });
            }
            services.AddTransient<ICacheService, CacheService>();
        }
    }
}
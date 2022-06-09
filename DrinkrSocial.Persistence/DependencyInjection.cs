
using DrinkrSocial.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DrinkrSocial.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Text;
using DrinkrSocial.Persistence.Settings;
using DrinkrSocial.Application.Interfaces.Repositories;

namespace DrinkrSocial.Persistence
{
    public static class DependencyInjection
    {
        public static void AddInfrastructreServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CAContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("PostgreSqlConnection"));
            });

            services.Configure<JWTSettings>(configuration.GetSection("JWTSettings"));
            services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
            services.Configure<CacheSettings>(configuration.GetSection("CacheSettings"));

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITokenRefreshRepository, TokenRefreshRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<ITokenService, TokenService>();



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
            services.AddTransient<IEasyCacheService, EasyCacheService>();
        }
    }
}
﻿using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace DrinkrSocial.Application
{
    public static class DependencyInjection
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
        }
    }
}
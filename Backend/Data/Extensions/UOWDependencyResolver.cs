using Core.Repositories.Contracts;
using Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Extensions
{
    public static class UOWDependencyResolver
    {
        public static void AddUOW(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IJournalRepository, JournalRepository>();
            services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();

        }

    }
}

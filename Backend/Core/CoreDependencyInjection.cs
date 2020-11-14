using Core.Services;
using Core.Services.Contracts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public static class CoreDependencyInjection
    {
        public static void AddCore(this IServiceCollection services)
        {
            services.AddScoped<IPasswordAuthenticationService, PasswordAuthenticationService>();
            services.AddScoped<IQuestionAuthenticationService, QuestionAuthenticationService>();
        }
    }
}

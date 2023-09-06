using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Data.Interfaces;
using Business.Interfaces;
using Business.Services;
using Business.Mappers;
using Mappers.DependencyInjection;

namespace Services
{
    public static class DependencyContainer
    {
        public static IServiceCollection RegisterBusiness(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IEmailRepository, EmailRepository>();
            services.AddScoped<IEmailService, EmailService>();

            services.AddOnlineStoreAutoMapper(new EmailProfile());
            return services;
        }
    }
}

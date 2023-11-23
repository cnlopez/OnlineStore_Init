using Data.Interfaces;
using Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Interfaces;
using Business.Services;
using Services2.Interfaces;
using Services2;
using Business.Mappers;
using Mappers.DependencyInjection;

namespace Services.Ioc
{
    public static class DependencyContainer
    {
        public static IServiceCollection RegisterBusiness(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IEmailService, EmailService>();

            services.AddOnlineStoreAutoMapper(new ProductProfile());
            return services;
        }
    }
}

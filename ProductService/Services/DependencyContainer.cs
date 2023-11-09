using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Data;
using Data.Interfaces;
using Business.Interfaces;
using Business.Services;
using Business.Mappers;
using Mappers.DependencyInjection;
using Services2.Interfaces;
using Services2;

namespace Services
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

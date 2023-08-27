using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mappers
{
    [ExcludeFromCodeCoverage]
    public static class CollectionExtensions
    {
        public static IServiceCollection AddOnlineStoreAutoMapper(this IServiceCollection services, params Profile[] profiles)
        {
            return services.AddAutoMapper(x =>
            {
                foreach (var profile in profiles)
                    x.AddProfile(profile);
            });
        }
    }
}

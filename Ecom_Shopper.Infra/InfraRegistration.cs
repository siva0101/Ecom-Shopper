using Ecom_Shopper.Domain.Interface;
using Ecom_Shopper.Infra.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom_Shopper.Infra
{
    public static class InfraRegistration
    {
        public static IServiceCollection AddInfraService(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));
            services.AddScoped<IProductRepository,ProductRepository>();
            return services;
        }
    }
}

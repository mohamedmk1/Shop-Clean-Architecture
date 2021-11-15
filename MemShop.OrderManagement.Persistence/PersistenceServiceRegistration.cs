using AutoMapper.Configuration;
using MemShop.OrderManagement.Application.Contracts.Persistence;
using MemShop.OrderManagement.Application.Contracts.Persistence.Customers;
using MemShop.OrderManagement.Persistence.Customers;
using Microsoft.Extensions.DependencyInjection;

namespace MemShop.OrderManagement.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            // TODO: Add Db Context

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));

            services.AddScoped<ICustomerRepository, CustomerRepository>();

            return services;
        }
    }
}

using MemShop.OrderManagement.Domain.Entities.Customers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MemShop.OrderManagement.Application.Contracts.Persistence.Customers
{
    public interface ICustomerRepository : IAsyncRepository<Customer>
    {
        Task<List<Customer>> GetCustomersWithOrders(bool includeHistory);
        Task<List<Customer>> GetCustomersByType(CustomerType CustomerTypeId);
        Task<bool> IsCustomerExist(string email, Guid exceptForCustomerId = default);
    }
}

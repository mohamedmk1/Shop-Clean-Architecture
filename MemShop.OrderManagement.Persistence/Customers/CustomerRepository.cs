using MemShop.OrderManagement.Application.Contracts.Persistence.Customers;
using MemShop.OrderManagement.Domain.Entities.Customers;

namespace MemShop.OrderManagement.Persistence.Customers
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(OrderManagementDbContext dbContext) : base(dbContext)
        {
        }

        public Task<List<Customer>> GetCustomersByType(CustomerType CustomerTypeId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Customer>> GetCustomersWithOrders(bool includeHistory)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsCustomerExist(string email, Guid exceptForCustomerId = default)
        {
            throw new NotImplementedException();
        }
    }
}

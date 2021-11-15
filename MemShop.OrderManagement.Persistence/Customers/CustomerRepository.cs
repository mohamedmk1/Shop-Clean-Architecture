using MemShop.OrderManagement.Application.Contracts.Persistence.Customers;
using MemShop.OrderManagement.Domain.Entities.Customers;
using Microsoft.EntityFrameworkCore;

namespace MemShop.OrderManagement.Persistence.Customers
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(OrderManagementDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Customer>> GetCustomersByType(CustomerType customerTypeId)
        {
            return await _dbContext.Customers.Where(c => c.CustomerType == customerTypeId).ToListAsync();
        }

        public Task<List<Customer>> GetCustomersWithOrders(bool includeHistory)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsCustomerExist(string email, Guid exceptForCustomerId = default)
        {
            if (exceptForCustomerId == default(Guid))
            {
                return Task.FromResult(_dbContext.Customers.Any(c => c.Email.Equals(email) && c.CustomerId != exceptForCustomerId));
            }
            return Task.FromResult(_dbContext.Customers.Any(c => c.Email.Equals(email)));
        }
    }
}

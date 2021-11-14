using MemShop.OrderManagement.Domain.Entities.Customers;
using System.Collections.Generic;

namespace MemShop.OrderManagement.Application.Features.Customers.Queries.GetCustomersListByType
{
    public class CustomerListByTypeVm
    {
        public CustomerType CustomerType { get; set; }
        public ICollection<CustomerDto> Customers { get; set; }
    }
}

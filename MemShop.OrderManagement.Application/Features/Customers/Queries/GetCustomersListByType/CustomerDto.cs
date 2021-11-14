using System;

namespace MemShop.OrderManagement.Application.Features.Customers.Queries.GetCustomersListByType
{
    public class CustomerDto
    {
        public Guid CustomerId { get; set; }
        public string Name { get; set; }
    }
}

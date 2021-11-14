using System;
using System.Collections.Generic;

namespace MemShop.OrderManagement.Application.Features.Customers.Queries.GetCustomersListWithOrders
{
    public class CustomerOrderListVm
    {
        public Guid CustomerId { get; set; }
        public string Name { get; set; }
        public ICollection<OrderDto> Orders { get; set; }
    }
}

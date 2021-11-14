using System;

namespace MemShop.OrderManagement.Application.Features.Customers.Queries.GetCustomersListWithOrders
{
    public class OrderDto
    {
        public Guid OrderId { get; set; }
        public decimal Total { get; set; }
    }
}

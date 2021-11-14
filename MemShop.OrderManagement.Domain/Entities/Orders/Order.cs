using MemShop.OrderManagement.Domain.Entities.Customers;
using System;

namespace MemShop.OrderManagement.Domain.Entities.Orders
{
    public class Order : AuditableEntity
    {
        public Guid OrderId { get; set; }
        public Customer Customer { get; set; }
        public decimal Total { get; set; }
    }
}

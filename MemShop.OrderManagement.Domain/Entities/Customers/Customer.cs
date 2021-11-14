using System;

namespace MemShop.OrderManagement.Domain.Entities.Customers
{
    public class Customer : AuditableEntity
    {
        public Guid CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Adresse { get; set; }
        public int ZipCode { get; set; }
        public CustomerType CustomerType { get; set; }
        public Guid CustomerTypeId { get; set; }

    }
}

using MemShop.OrderManagement.Domain.Entities.Customers;
using System;

namespace MemShop.OrderManagement.Application.Features.Customers.Queries.GetCustomerDetail
{
    public class CustomerDetailVm
    {
        public Guid CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Adresse { get; set; }
        public int ZipCode { get; set; }
        public string Email { get; set; }
        public CustomerType CustomerTypeId { get; set; }
        public CustomerTypeDto CustomerType { get; set; }
    }
}

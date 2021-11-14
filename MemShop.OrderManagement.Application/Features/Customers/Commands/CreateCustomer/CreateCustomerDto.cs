using MemShop.OrderManagement.Domain.Entities.Customers;
using System;

namespace MemShop.OrderManagement.Application.Features.Customers.Commands.CreateCustomer
{
    public class CreateCustomerDto
    {
        public Guid CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Adresse { get; set; }
        public string ZipCode { get; set; }
        public string Email { get; set; }
        public CustomerType CustomerType { get; set; }
    }
}

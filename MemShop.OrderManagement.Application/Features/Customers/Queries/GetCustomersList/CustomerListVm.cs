using System;

namespace MemShop.OrderManagement.Application.Features.Customers.GetCustomersList
{
    public class CustomerListVm
    {
        public Guid CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Adresse { get; set; }
        public string ZipCode { get; set; }
        public string Email { get; set; }
    }
}
using MemShop.OrderManagement.Domain.Entities.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemShop.OrderManagement.Application.Features.Customers.Commands.UpdateCustomer
{
    public class UpdateCustomerDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Adresse { get; set; }
        public string ZipCode { get; set; }
        public CustomerType CustomerType { get; set; }
    }
}

using MediatR;
using MemShop.OrderManagement.Domain.Entities.Customers;
using System;

namespace MemShop.OrderManagement.Application.Features.Customers.Commands.CreateCustomer
{
    public class CreateCustomerCommand : IRequest<CreateCustomerCommandResponse>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Adresse { get; set; }
        public int ZipCode { get; set; }
        public string Email { get; set; }
        public CustomerType CustomerType { get; set; }

        public override string ToString()
        {
            return $"Customer name: {FirstName} {LastName}; Adresse: {Adresse} {ZipCode}, Email: {Email}, Type: {CustomerType}";
        }
    }
}

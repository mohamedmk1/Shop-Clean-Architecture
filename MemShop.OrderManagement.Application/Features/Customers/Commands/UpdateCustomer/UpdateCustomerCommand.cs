using MediatR;
using MemShop.OrderManagement.Domain.Entities.Customers;
using System;

namespace MemShop.OrderManagement.Application.Features.Customers.Commands.UpdateCustomer
{
    public class UpdateCustomerCommand : IRequest<UpdateCustomerCommandResponse>
    {
        public Guid CustomerId { get; set; }
        public string Adresse { get; set; }
        public int ZipCode { get; set; }
        public string Email { get; set; }
        public CustomerType CustomerType { get; set; }
    }
}

using MediatR;
using System;

namespace MemShop.OrderManagement.Application.Features.Customers.Commands.DeleteCustomer
{
    public class DeleteCustomerCommand : IRequest
    {
        public Guid CustomerId { get; set; }
    }
}

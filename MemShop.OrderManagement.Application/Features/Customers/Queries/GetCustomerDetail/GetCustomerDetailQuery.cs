using MediatR;
using System;

namespace MemShop.OrderManagement.Application.Features.Customers.Queries.GetCustomerDetail
{
    public class GetCustomerDetailQuery : IRequest<CustomerDetailVm>
    {
        public Guid Id { get; set; }
    }
}

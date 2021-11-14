using MediatR;
using System.Collections.Generic;

namespace MemShop.OrderManagement.Application.Features.Customers.Queries.GetCustomersListWithOrders
{
    public class GetCustomersListWithOrdersQuery : IRequest<List<CustomerOrderListVm>>
    {
        public bool IncludeHistory { get; set; }
    }
}

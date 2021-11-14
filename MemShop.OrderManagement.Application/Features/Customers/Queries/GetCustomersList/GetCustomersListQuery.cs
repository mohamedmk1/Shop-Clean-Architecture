using MediatR;
using System.Collections.Generic;

namespace MemShop.OrderManagement.Application.Features.Customers.GetCustomersList
{
    public class GetCustomersListQuery : IRequest<List<CustomerListVm>>
    {

    }
}

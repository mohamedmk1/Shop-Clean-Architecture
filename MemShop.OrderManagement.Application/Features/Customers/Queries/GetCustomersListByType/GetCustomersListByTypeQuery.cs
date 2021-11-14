using MediatR;
using MemShop.OrderManagement.Domain.Entities.Customers;
using System;
using System.Collections.Generic;

namespace MemShop.OrderManagement.Application.Features.Customers.Queries.GetCustomersListByType
{
    public class GetCustomersListByTypeQuery : IRequest<List<CustomerListByTypeVm>>
    {
        public CustomerType CustomerType { get; set; }
    }
}

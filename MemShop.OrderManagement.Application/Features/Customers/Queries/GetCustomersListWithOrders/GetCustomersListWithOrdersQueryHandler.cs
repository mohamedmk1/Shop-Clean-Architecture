using AutoMapper;
using MediatR;
using MemShop.OrderManagement.Application.Contracts.Persistence.Customers;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MemShop.OrderManagement.Application.Features.Customers.Queries.GetCustomersListWithOrders
{
    public class GetCustomersListWithOrdersQueryHandler : IRequestHandler<GetCustomersListWithOrdersQuery, List<CustomerOrderListVm>>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public GetCustomersListWithOrdersQueryHandler(IMapper mapper, ICustomerRepository customerRepository)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
        }

        public async Task<List<CustomerOrderListVm>> Handle(GetCustomersListWithOrdersQuery request, CancellationToken canclllationToken)
        {
            var customersWithOrdersDto = await _customerRepository.GetCustomersWithOrders(request.IncludeHistory);
            return _mapper.Map<List<CustomerOrderListVm>>(customersWithOrdersDto);
        }
    }
}

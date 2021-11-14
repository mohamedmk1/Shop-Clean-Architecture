using AutoMapper;
using MediatR;
using MemShop.OrderManagement.Application.Contracts.Persistence.Customers;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MemShop.OrderManagement.Application.Features.Customers.Queries.GetCustomersListByType
{
    public class GetCustomerListByTypeQueryHandler : IRequestHandler<GetCustomersListByTypeQuery, List<CustomerListByTypeVm>>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;

        public GetCustomerListByTypeQueryHandler(IMapper mapper, ICustomerRepository customerRepository)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
        }

        public async Task<List<CustomerListByTypeVm>> Handle(GetCustomersListByTypeQuery request, CancellationToken cancellationToken)
        {
            var customersByTypeDto = await _customerRepository.GetCustomersByType(request.CustomerType);
            return _mapper.Map<List<CustomerListByTypeVm>>(customersByTypeDto);
        }
    }
}

using AutoMapper;
using MediatR;
using MemShop.OrderManagement.Application.Contracts.Persistence;
using MemShop.OrderManagement.Domain.Entities.Customers;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MemShop.OrderManagement.Application.Features.Customers.GetCustomersList
{
    public class GetCustomersListQueryHandler : IRequestHandler<GetCustomersListQuery, List<CustomerListVm>>
    {
        private readonly IAsyncRepository<Customer> _customerRepository;
        private readonly IMapper _mapper;

        public GetCustomersListQueryHandler(IMapper mapper, IAsyncRepository<Customer> customerRepository)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
        }

        public async Task<List<CustomerListVm>> Handle(GetCustomersListQuery request, CancellationToken cancellationToken)
        {
            var allCustomers = (await _customerRepository.ListAllAsync()).OrderBy(c => c.LastName);
            return _mapper.Map<List<CustomerListVm>>(allCustomers);
        }
    }
}

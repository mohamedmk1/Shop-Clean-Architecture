using AutoMapper;
using MediatR;
using MemShop.OrderManagement.Application.Contracts.Persistence;
using MemShop.OrderManagement.Domain.Entities.Customers;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MemShop.OrderManagement.Application.Features.Customers.Queries.GetCustomerDetail
{
    public class GetCustomerDetailQueryHandler : IRequestHandler<GetCustomerDetailQuery, CustomerDetailVm>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Customer> _customerRepository;

        public GetCustomerDetailQueryHandler(IMapper mapper, IAsyncRepository<Customer> customerRepository)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
        }

        public async Task<CustomerDetailVm> Handle(GetCustomerDetailQuery request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetByIdAsync(request.Id);
            var customerDetailDto = _mapper.Map<CustomerDetailVm>(customer);
            int customerTypeId = (int)customerDetailDto.CustomerTypeId;

            customerDetailDto.CustomerType.Id = customerTypeId;
            customerDetailDto.CustomerType.Label = Enum.GetName(typeof(CustomerType), customerTypeId);

            return customerDetailDto;
        }
    }
}

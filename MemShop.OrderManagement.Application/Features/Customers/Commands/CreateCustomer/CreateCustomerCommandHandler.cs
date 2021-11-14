using AutoMapper;
using MediatR;
using MemShop.OrderManagement.Application.Contracts.Persistence;
using MemShop.OrderManagement.Application.Contracts.Persistence.Customers;
using MemShop.OrderManagement.Domain.Entities.Customers;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MemShop.OrderManagement.Application.Features.Customers.Commands.CreateCustomer
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, CreateCustomerCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;

        public CreateCustomerCommandHandler(IMapper mapper, ICustomerRepository customerRepository)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
        }

        public async Task<CreateCustomerCommandResponse> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var createCustomerCommandResponse = new CreateCustomerCommandResponse();

            var validator = new CreateCustomerCommandValidator(_customerRepository);
            var validationResult = await validator.ValidateAsync(request);

            if(validationResult.Errors.Count > 0)
            {
                createCustomerCommandResponse.Success = false;
                createCustomerCommandResponse.ValidationErrors = new List<string>();
                foreach(var error in validationResult.Errors)
                {
                    createCustomerCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }
            
            if (createCustomerCommandResponse.Success)
            {
                var customer = _mapper.Map<Customer>(request);
                customer = await _customerRepository.AddAsync(customer);
                createCustomerCommandResponse.Customer = _mapper.Map<CreateCustomerDto>(customer);
            }


            return createCustomerCommandResponse;
        }
    }
}

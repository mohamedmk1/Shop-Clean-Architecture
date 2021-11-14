using AutoMapper;
using MediatR;
using MemShop.OrderManagement.Application.Contracts.Persistence.Customers;
using MemShop.OrderManagement.Domain.Entities.Customers;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MemShop.OrderManagement.Application.Features.Customers.Commands.UpdateCustomer
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, UpdateCustomerCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;

        public UpdateCustomerCommandHandler(IMapper mapper, ICustomerRepository customerRepository)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
        }

        public async Task<UpdateCustomerCommandResponse> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var updateCustomerCommandResponse = new UpdateCustomerCommandResponse();

            var validator = new UpdateCustomerCommandValidator(_customerRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                updateCustomerCommandResponse.Success = false;
                updateCustomerCommandResponse.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    updateCustomerCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }

            if (updateCustomerCommandResponse.Success)
            {
                var customerToUpdate = await _customerRepository.GetByIdAsync(request.CustomerId);
                _mapper.Map(request, customerToUpdate, typeof(UpdateCustomerCommand), typeof(Customer));

                await _customerRepository.UpdateAsync(customerToUpdate);
            }


            return updateCustomerCommandResponse;
        }
    }
}

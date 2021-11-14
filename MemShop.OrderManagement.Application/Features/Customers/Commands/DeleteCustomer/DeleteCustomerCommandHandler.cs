using MediatR;
using MemShop.OrderManagement.Application.Contracts.Persistence;
using MemShop.OrderManagement.Domain.Entities.Customers;
using System.Threading;
using System.Threading.Tasks;

namespace MemShop.OrderManagement.Application.Features.Customers.Commands.DeleteCustomer
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand>
    {
        private readonly IAsyncRepository<Customer> _customerRepository;

        public DeleteCustomerCommandHandler(IAsyncRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Unit> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var customerToDelete = await _customerRepository.GetByIdAsync(request.CustomerId);

            await _customerRepository.DeleteAsync(customerToDelete);

            return Unit.Value;
        }
    }
}

using FluentValidation;
using MemShop.OrderManagement.Application.Contracts.Persistence.Customers;
using System.Threading;
using System.Threading.Tasks;

namespace MemShop.OrderManagement.Application.Features.Customers.Commands.UpdateCustomer
{
    public class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
    {
        private readonly ICustomerRepository _customerRepository;

        public UpdateCustomerCommandValidator(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;

            RuleFor(c => c.Adresse)
                    .MaximumLength(255).WithMessage("{PropertyName} must not exceed 255 characters.");

            RuleFor(c => c.ZipCode)
                    .GreaterThan(9999)
                    .LessThan(100000)
                    .WithMessage("{PropertyName} must contains exactly 5 digits.");

            RuleFor(c => c)
                .MustAsync(CustomerUnique)
                .WithMessage("A customer with the same email already exists.");

            RuleFor(c => c.CustomerType)
                .IsInEnum()
                .WithMessage("{PropertyName} has a range of value which does not include {PropertyValue}.");
        }

        private async Task<bool> CustomerUnique(UpdateCustomerCommand c, CancellationToken token)
        {
            return !(await _customerRepository.IsCustomerExist(c.Email, c.CustomerId));
        }
    }
}

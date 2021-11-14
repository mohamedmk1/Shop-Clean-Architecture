using FluentValidation;
using MemShop.OrderManagement.Application.Contracts.Persistence.Customers;
using System.Threading;
using System.Threading.Tasks;

namespace MemShop.OrderManagement.Application.Features.Customers.Commands.CreateCustomer
{
    public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
    {
        private readonly ICustomerRepository _customerRepository;

        public CreateCustomerCommandValidator(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;

            RuleFor(c => c.FirstName)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull()
               .NotEqual(c => c.LastName).WithMessage("First name must be different from Last name.")
               .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(c => c.LastName)
                    .NotEmpty().WithMessage("{PropertyName} is required.")
                    .NotNull()
                    .NotEqual(c => c.FirstName).WithMessage("First name must be different from Last name.")
                    .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(c => c.Email)
                   .NotEmpty().WithMessage("{PropertyName} is required.")
                   .NotNull()
                   .EmailAddress().WithMessage("Please enter a valid email address.")
                   .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(c => c.Adresse)
                    .MaximumLength(255).WithMessage("{PropertyName} must not exceed 255 characters.");

            RuleFor(c => c.ZipCode)
                    .GreaterThan(9999)
                    .LessThan(100000)
                    .WithMessage("{PropertyName} must contains exactly 5 digits.");

            RuleFor(c => c.CustomerType)
                .IsInEnum()
                .WithMessage("{PropertyName} has a range of value which does not include {PropertyValue}.");

            RuleFor(c => c)
                .MustAsync(CustomerUnique)
                .WithMessage("A customer with the same email already exists.");
        }

        private async Task<bool> CustomerUnique(CreateCustomerCommand c, CancellationToken token)
        {
            return !(await _customerRepository.IsCustomerExist(c.Email));
        }
    }
}

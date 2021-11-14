using MemShop.OrderManagement.Application.Responses;

namespace MemShop.OrderManagement.Application.Features.Customers.Commands.CreateCustomer
{
    public class CreateCustomerCommandResponse : BaseResponse
    {
        public CreateCustomerCommandResponse(): base()
        {

        }

        public CreateCustomerDto Customer { get; set; }
    }
}

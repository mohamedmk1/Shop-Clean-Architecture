using MemShop.OrderManagement.Application.Responses;

namespace MemShop.OrderManagement.Application.Features.Customers.Commands.UpdateCustomer
{
    public class UpdateCustomerCommandResponse : BaseResponse
    {
        public UpdateCustomerCommandResponse()
        {

        }

        public UpdateCustomerDto Customer { get; set; }
    }
}

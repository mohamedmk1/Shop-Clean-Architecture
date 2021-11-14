using AutoMapper;
using MemShop.OrderManagement.Application.Features.Customers.Commands.CreateCustomer;
using MemShop.OrderManagement.Application.Features.Customers.Commands.DeleteCustomer;
using MemShop.OrderManagement.Application.Features.Customers.Commands.UpdateCustomer;
using MemShop.OrderManagement.Application.Features.Customers.GetCustomersList;
using MemShop.OrderManagement.Application.Features.Customers.Queries.GetCustomerDetail;
using MemShop.OrderManagement.Application.Features.Customers.Queries.GetCustomersListByType;
using MemShop.OrderManagement.Application.Features.Customers.Queries.GetCustomersListWithOrders;
using MemShop.OrderManagement.Domain.Entities.Customers;

namespace MemShop.OrderManagement.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerListVm>().ReverseMap();
            CreateMap<Customer, CustomerDetailVm>().ReverseMap();
            CreateMap<Customer, CustomerOrderListVm>();
            CreateMap<Customer, CustomerDto>();
            CreateMap<Customer, CustomerListByTypeVm>();
            CreateMap<Customer, CreateCustomerCommand>().ReverseMap();
            CreateMap<Customer, CreateCustomerDto>();
            CreateMap<Customer, UpdateCustomerCommand>().ReverseMap();
            CreateMap<Customer, DeleteCustomerCommand>().ReverseMap();
        }
    }
}

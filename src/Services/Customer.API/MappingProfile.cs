using AutoMapper;
using Common.Shared.DTOs.Customer;
using Customer.API.Entities;
using Common.Infas.Mappings;
namespace Customer.API
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CustomerEntity, CustomerDto>();
            CreateMap<CreateCustomerDto, CustomerEntity>();
            CreateMap<UpdateCustomerDto, CustomerEntity>()
                .IgnoreAllNonExisting() //[Extension method]: Ignore fields non existing when map
                .IgnoreNullProperties(); //[Extension method]: Ignore fields that has null value
        }
    }
}

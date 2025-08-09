using AutoMapper;
using Common.Shared.DTOs.Product;
using Product.API.Entities;
using Common.Infas.Mappings;
namespace Product.API
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductEntity, ProductDto>();
            CreateMap<CreateProductDto, ProductEntity>();
            CreateMap<UpdateProductDto, ProductEntity>()
                .IgnoreAllNonExisting() //[Extension method]: Ignore fields non existing when map
                .IgnoreNullProperties(); //[Extension method]: Ignore fields that has null value
        }
    }
}

using AutoMapper;
using Cart.App.DTO;
using Cart.Business.Models;

namespace Cart.App.Configuration
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Supplier, SupplierDTO>().ReverseMap();
            CreateMap<Address, AddressDTO>().ReverseMap();  
            CreateMap<Product, ProductDTO>().ReverseMap();
        }
    }
}

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
            
            CreateMap<ProductInputDTO, Product>();
            CreateMap<Product, ProductViewDTO>()
                .ForMember(p => p.SupplierId, options => options.MapFrom(p=>p.Supplier.Id))
                .ForMember(p=>p.NameSupplier, opt=>opt.MapFrom(p=>p.Supplier.Name));
        }
    }
}

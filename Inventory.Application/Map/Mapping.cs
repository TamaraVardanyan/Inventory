using AutoMapper;
using Inventory.Infrastructure.DTOs;
using Inventory.Infrastructure.Models;

namespace Inventory.Application.Map
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Supplier, SupplierDTO>().ReverseMap();
            CreateMap<Transaction, TransactionDTO>().ReverseMap();
            CreateMap<UserDTO, User>()
            .ForMember(dest => dest.Password, opt => opt.Ignore()); 
        }
    }
}

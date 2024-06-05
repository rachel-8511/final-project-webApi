using AutoMapper;
using Entities;
using DTOs;
namespace Project
{
    public class AutoMapper:Profile
    {
        public AutoMapper()
        {
            CreateMap<Product, ProductDTO>().ForMember(dest=>dest.CategoryName,
                opts=>opts.MapFrom(src=>src.Category.CategoryName)).ReverseMap();
            CreateMap<User, UserLoginDTO>().ReverseMap();
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Order, OrderDTO>().ReverseMap();
            CreateMap<OrderItem, OrderItemDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();


        }
    }
}

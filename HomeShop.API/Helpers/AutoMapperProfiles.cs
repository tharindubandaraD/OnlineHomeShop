using System.Linq;
using AutoMapper;
using HomeShop.API.Dtos;
using HomeShop.API.Dtos.OrderDto;
using HomeShop.API.Dtos.OrderProductDto;
using HomeShop.API.Model;

namespace HomeShop.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
           CreateMap<Product, ProductListDto>()
            .ForMember(dest => dest.PhotoUrl, opt => 
                opt.MapFrom(src => src.Photos.FirstOrDefault( p=> p.IsMain).Url));
           
           CreateMap<Product, ProductDetailDto>()
            .ForMember(dest => dest.PhotoUrl, opt => 
                opt.MapFrom(src => src.Photos.FirstOrDefault( p=> p.IsMain).Url));

           CreateMap<Photo, PhotosForDetailDto>();

           CreateMap<Category, CategoryForDetailDto>();      

           CreateMap<Brand, BrandforDetailDto>();  

           CreateMap<OrderDto, Order>();

          CreateMap<OrderProductDto, OrderProduct>();

          CreateMap<UserForRegisterDto, User>();

          CreateMap<User, UserForLoginDtos>();

        }
    }
}
using AutoMapper;
using HomeShop.Entity.Dtos;
using HomeShop.DataAccess.Model;
using System.Linq;

namespace HomeShop.DataAccess.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {

            CreateMap<Product, ProductListDto>()
             .ForMember(dest => dest.PhotoUrl, opt =>
                 opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url));

            CreateMap<Product, ProductDetailDto>()
             .ForMember(dest => dest.PhotoUrl, opt =>
                 opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url));

            CreateMap<Photo, PhotosForDetailDto>();

            CreateMap<Category, CategoryForDetailDto>();

            CreateMap<Brand, BrandforDetailDto>();
             
            CreateMap<OrderDto, Order>().ReverseMap();

            CreateMap<OrderProductDto, OrderProduct>();

            CreateMap<UserForRegisterDto, User>();

            CreateMap<User, UserForLoginDtos>();
        }
    }
}

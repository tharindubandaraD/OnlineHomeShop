using AutoMapper;
using HomeShop.DataAccess.Model;
using HomeShop.Entity.Dtos;
using System.Linq;

namespace HomeShop.DataAccess.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        /// <summary>Initializes a new instance of the <see cref="AutoMapperProfiles" /> class.</summary>
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

            CreateMap<OrderProductDto, OrderProduct>()
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.Id));

            CreateMap<UserForRegisterDto, User>();

            CreateMap<User, UserForLoginDtos>();

            CreateMap<User, UserForOrderDto>();
        }
    }
}

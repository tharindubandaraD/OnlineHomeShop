using System.Linq;
using AutoMapper;
using HomeShop.API.Dtos;
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

           CreateMap<Category, CategoryForDetailDto>();  

           CreateMap<Brand, BrandforDetailDto>();  

           CreateMap<Photo, PhotosForDetailDto>();
        }
    }
}
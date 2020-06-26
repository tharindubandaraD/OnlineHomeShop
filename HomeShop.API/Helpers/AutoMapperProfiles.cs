using AutoMapper;
using HomeShop.API.Dtos;
using HomeShop.API.Model;

namespace HomeShop.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
           CreateMap<Product, ProductListDto>();
           
           CreateMap<Product, ProductDetailDto>();

           CreateMap<Photo, PhotosForDetailDto>();
        }
    }
}
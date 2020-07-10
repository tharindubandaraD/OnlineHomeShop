using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HomeShop.API.Data;
using HomeShop.API.Data.CategoryRepository;
using HomeShop.API.Dtos;
using HomeShop.API.Model;

namespace HomeShop.API.Business._Category
{
    public class CategoryBusinessLayer : ICategoryBusinessLayer
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryBusinessLayer(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;

        }
        async Task<IEnumerable<CategoryForDetailDto>> ICategoryBusinessLayer.GetCategory()
        {
            var categories = await  _categoryRepository.GetCategory();
            var mapcategories = _mapper.Map<IEnumerable<CategoryForDetailDto>>(categories);
            return mapcategories;
        }
    }
}
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HomeShop.API.Data;
using HomeShop.API.Data.CategoryRepository;
using HomeShop.Entity.Dtos;

namespace HomeShop.API.Business.Category
{
    public class CategoryManager : ICategoryManager
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryManager(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;

        }
        async Task<IEnumerable<CategoryForDetailDto>> ICategoryManager.GetCategory()
        {
            var categories = await  _categoryRepository.GetCategory();
            var mapcategories = _mapper.Map<IEnumerable<CategoryForDetailDto>>(categories);
            return mapcategories;
        }
    }
}
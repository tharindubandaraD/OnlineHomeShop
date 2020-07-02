using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HomeShop.API.Data.CategoryRepository;
using HomeShop.API.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HomeShop.API.Controller
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryController(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }
        [HttpGet]
        public async Task<IActionResult> getCategorties()
        {
            var categoryRepository = await _categoryRepository.GetCategory();
            var mapcategories = _mapper.Map<IEnumerable<CategoryForDetailDto>>(categoryRepository);
            
            return Ok(mapcategories);
        }
    }
}
using System.Threading.Tasks;
using HomeShop.API.Business._Category;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HomeShop.API.Controller
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {       
        private readonly ICategoryBusinessLayer _categoryBusinessLayer;
        public CategoryController(ICategoryBusinessLayer categoryBusinessLayer)
        {
            _categoryBusinessLayer = categoryBusinessLayer;           
        }
        [HttpGet]
        public async Task<IActionResult> getCategorties()
        {
            var categories = await _categoryBusinessLayer.GetCategory();
            return Ok(categories);
        }

    }
}
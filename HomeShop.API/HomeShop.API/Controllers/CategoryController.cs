using HomeShop.API.Business.Category;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HomeShop.API.Controller
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryManager _categoryBusinessLayer;
        public CategoryController(ICategoryManager categoryBusinessLayer)
        {
            _categoryBusinessLayer = categoryBusinessLayer;
        }
        /// <summary>Gets the categorties.</summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetCategorties()
        {
            var categories = await _categoryBusinessLayer.GetCategory();
            return Ok(categories);
        }

    }
}
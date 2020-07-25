using HomeShop.API.Business;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HomeShop.API.Controller
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductManager _productBusinessLayer;
        public ProductController(IProductManager productBusinessLayer)
        {
            _productBusinessLayer = productBusinessLayer;
        }

        /// <summary>Gets the products.</summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            //gaeting data from db  
            var products = await _productBusinessLayer.GetProducts();
            return Ok(products);
        }

        /// <summary>Gets the product.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var productDetail = await _productBusinessLayer.GetProduct(id);
            return Ok(productDetail);
        }

        /// <summary>Getcategoryproducts the specified identifier.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet("category/{id}")]
        public async Task<IActionResult> Getcategoryproduct(int id)
        {
            var productbyCategory = await _productBusinessLayer.GetProductbyCategory(id);
            return Ok(productbyCategory);
        }


    }
}
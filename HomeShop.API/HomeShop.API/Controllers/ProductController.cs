using System.Collections.Generic;
using System.Threading.Tasks;
using HomeShop.API.Business;
using HomeShop.Entity.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            //gaeting data from db  
            var products = await _productBusinessLayer.GetProducts();              
            return Ok(products);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var productDetail = await _productBusinessLayer.GetProduct(id);
            return Ok(productDetail);
        }

       [HttpGet("category/{id}")]
        public async Task<IActionResult> getcategoryproduct(int id)
        {
            var productbyCategory = await _productBusinessLayer.GetProductbyCategory(id);
            return Ok(productbyCategory);
        }


    }
}
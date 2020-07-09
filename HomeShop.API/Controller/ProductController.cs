using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HomeShop.API.Business;
using HomeShop.API.Data;
using HomeShop.API.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HomeShop.API.Controller
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductBusinessLayer _productBusinessLayer;
        public ProductController(IProductBusinessLayer productBusinessLayer)
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
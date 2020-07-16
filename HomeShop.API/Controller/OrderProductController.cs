using System.Threading.Tasks;
using HomeShop.API.Business._OrderProduct;
using HomeShop.API.Dtos.OrderProductDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HomeShop.API.Controller
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderProductController : ControllerBase
    {
        private readonly IOrderProductBusinessLayer _orderProductBusinessObject;

        public OrderProductController(IOrderProductBusinessLayer orderProductBusinessObject)
        {           
            _orderProductBusinessObject = orderProductBusinessObject;
        }

        [HttpPost]
        public async Task<IActionResult> OrderProduct(OrderProductDto orderProductDto)
        {
            var orderProductBusiness = await _orderProductBusinessObject.SetOrderProduct(orderProductDto);
            return Ok(orderProductBusiness);
        }
    }
}
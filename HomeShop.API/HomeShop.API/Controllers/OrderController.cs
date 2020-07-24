using System.Threading.Tasks;
using HomeShop.API.Business.Order;
using HomeShop.Entity.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HomeShop.API.Controller
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderManager _orderBusinessLayer;
        public OrderController(IOrderManager orderBusinessLayer)
        {
           _orderBusinessLayer = orderBusinessLayer;

        }

        [HttpPost]
        public async Task<IActionResult> PostOrder(CommonDto commonDto)
        {
           var order =  await  _orderBusinessLayer.addOrder(commonDto);
           return Ok(order);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrder(int id)
        {
            var getorderdetails = await _orderBusinessLayer.getOrder(id);
            return Ok(getorderdetails);
        }

         [HttpDelete("{id}")]
         public async Task<IActionResult> DeleteOrder(int id)
         {
            await _orderBusinessLayer.deleteOrder(id);
            return Ok();
         }
    }
}
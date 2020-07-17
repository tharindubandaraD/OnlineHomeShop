using System.Threading.Tasks;
using HomeShop.API.Business._Order;
using HomeShop.API.Dtos.CommonDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HomeShop.API.Controller
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderBusinessLayer _orderBusinessLayer;
        public OrderController(IOrderBusinessLayer orderBusinessLayer)
        {
           _orderBusinessLayer = orderBusinessLayer;

        }
        [HttpPost]
        public async Task<IActionResult> PostOrder(CommonDto commonDto)
        {
           var order =  await  _orderBusinessLayer.addOrder(commonDto);
           return Ok(order);
        }
    }
}
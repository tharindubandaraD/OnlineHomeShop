using HomeShop.API.Business.Order;
using HomeShop.Entity.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HomeShop.API.Controller
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderManager _orderManager;
        public OrderController(IOrderManager orderManager)
        {
            _orderManager = orderManager;
        }

        /// <summary>Posts the order.</summary>
        /// <param name="commonDto">The common dto.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> PostOrder(OrderDto orderDto)
        {
            var order = await _orderManager.AddOrder(orderDto);
            return Ok(order);
        }

        /// <summary>Gets the order.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrder(int id)
        {
            var getorderdetails = await _orderManager.GetOrder(id);
            return Ok(getorderdetails);
        }

        /// <summary>Deletes the order.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            await _orderManager.DeleteOrder(id);
            return Ok();
        }

        [HttpGet("orderinformation/{id}")]
        public async Task<IActionResult> OrderInformation(int id)
        {
            return Ok(await _orderManager.GetOrderInfromation(id));
        }

    }
}
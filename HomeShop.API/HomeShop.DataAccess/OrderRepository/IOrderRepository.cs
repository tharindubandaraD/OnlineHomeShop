using System.Collections.Generic;
using System.Threading.Tasks;
using HomeShop.Entity.Dtos;

namespace HomeShop.API.Data.OrderRepository
{
    public interface IOrderRepository
    {
         Task<OrderDto> addOrder(OrderDto order);
         Task<OrderDto> CheckOrderStatus(int OrderId);
         Task<IEnumerable<GetOrderDetailDto>> GetOrder(int userId);       

    }
}
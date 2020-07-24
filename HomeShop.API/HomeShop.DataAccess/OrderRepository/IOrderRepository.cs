using HomeShop.Entity.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HomeShop.API.Data.OrderRepository
{
    public interface IOrderRepository
    {
        Task<OrderDto> addOrder(OrderDto orderDto);
        Task<OrderDto> CheckOrderStatus(int userId);
        Task<IEnumerable<GetOrderDetailDto>> GetOrder(int userId);

    }
}
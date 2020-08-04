using HomeShop.Entity.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HomeShop.API.Business.Order
{
    public interface IOrderManager
    {
        Task<OrderDto> AddOrder(OrderDto orderDto);
        Task<IEnumerable<GetOrderDetailDto>> GetOrder(int userId);
        Task<bool> DeleteOrder(int id);

    }
}
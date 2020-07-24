using HomeShop.Entity.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HomeShop.API.Business.Order
{
    public interface IOrderManager
    {
        Task<OrderDto> addOrder(CommonDto commonDto);
        Task<IEnumerable<GetOrderDetailDto>> getOrder(int userId);
        Task<bool> deleteOrder(int id);

    }
}
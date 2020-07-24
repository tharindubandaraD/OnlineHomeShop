using System.Collections.Generic;
using System.Threading.Tasks;
using HomeShop.Entity.Dtos;

namespace HomeShop.API.Business.Order
{
    public interface IOrderManager
    {
         Task<OrderDto> addOrder(CommonDto commonDto);
         Task<IEnumerable<GetOrderDetailDto>> getOrder(int userId);
         Task<bool> deleteOrder(int id);

    }
}
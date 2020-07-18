using System.Collections.Generic;
using System.Threading.Tasks;
using HomeShop.API.Dtos.CommonDto;
using HomeShop.API.Dtos.OrderDto;
using HomeShop.API.Model;

namespace HomeShop.API.Business._Order
{
    public interface IOrderBusinessLayer
    {
         Task<Order> addOrder(CommonDto commonDto);
         Task<IEnumerable<GetOrderDetailDto>> getOrder(int userId);
    }
}
using System.Threading.Tasks;
using HomeShop.API.Dtos.OrderDto;
using HomeShop.API.Model;

namespace HomeShop.API.Business._Order
{
    public interface IOrderBusinessLayer
    {
         Task<Order> addOrder(OrderDto orderDto);
    }
}
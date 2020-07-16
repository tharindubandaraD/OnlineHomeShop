using System.Threading.Tasks;
using HomeShop.API.Dtos.OrderProductDto;
using HomeShop.API.Model;

namespace HomeShop.API.Business._OrderProduct
{
    public interface IOrderProductBusinessLayer 
    {
         Task<OrderProduct> SetOrderProduct(OrderProductDto orderProductDto);
    }
}
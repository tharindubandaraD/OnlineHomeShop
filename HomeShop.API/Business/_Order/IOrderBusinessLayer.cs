using System.Threading.Tasks;
using HomeShop.API.Dtos.CommonDto;
using HomeShop.API.Model;

namespace HomeShop.API.Business._Order
{
    public interface IOrderBusinessLayer
    {
         Task<Order> addOrder(CommonDto commonDto);
    }
}
using System.Threading.Tasks;
using HomeShop.API.Model;

namespace HomeShop.API.Data.OrderRepository
{
    public interface IOrderRepository
    {
         Task<Order> addOrder(Order order);
         Task<Order> CheckOrderStatus(int OrderId);
    }
}
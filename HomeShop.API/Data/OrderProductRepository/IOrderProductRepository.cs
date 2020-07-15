using System.Threading.Tasks;
using HomeShop.API.Model;

namespace HomeShop.API.Data.OrderProductRepository
{
    public interface IOrderProductRepository
    {
         Task<OrderProduct> addOrderProduct(OrderProduct orderProduct);
    }
}
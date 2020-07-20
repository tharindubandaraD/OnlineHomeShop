using System.Threading.Tasks;
using HomeShop.API.Model;

namespace HomeShop.API.Data.OrderProductRepository
{
    public interface IOrderProductRepository
    {
         Task<OrderProduct> addOrderProduct(OrderProduct orderProduct);
        void Delete<T>(T entity) where T: class;
         Task<bool> SaveAll();         
         Task<OrderProduct> GetOrderProduct(int i); 
    }
}
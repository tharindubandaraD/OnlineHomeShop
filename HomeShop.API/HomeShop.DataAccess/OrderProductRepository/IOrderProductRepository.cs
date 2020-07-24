using System.Threading.Tasks;
using HomeShop.Entity.Dtos;

namespace HomeShop.API.Data.OrderProductRepository
{
    public interface IOrderProductRepository
    {
         Task<OrderProductDto> addOrderProduct(OrderProductDto orderProduct);
         void Delete<T>(T entity) where T: class;
         Task<bool> SaveAll();         
         Task<OrderProductDto> GetOrderProduct(int i); 
    }
}
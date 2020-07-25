using HomeShop.Entity.Dtos;
using System.Threading.Tasks;

namespace HomeShop.API.Data.OrderProductRepository
{
    public interface IOrderProductRepository
    {
        Task<OrderProductDto> AddOrderProduct(OrderProductDto orderProductDto);
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveAll();
        Task<OrderProductDto> GetOrderProduct(int i);
    }
}
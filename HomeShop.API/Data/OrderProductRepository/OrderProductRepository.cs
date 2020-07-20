using System.Threading.Tasks;
using HomeShop.API.Model;

namespace HomeShop.API.Data.OrderProductRepository
{
    public class OrderProductRepository : IOrderProductRepository
    {
        private readonly DataContext _dataContext;

        public OrderProductRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<OrderProduct> addOrderProduct(OrderProduct orderProduct)
        {
            await _dataContext.OrderProducts.AddAsync(orderProduct);
            await _dataContext.SaveChangesAsync();
            return orderProduct;
        }

      public void Delete<T>(T entity) where T : class
        {
           _dataContext.Remove(entity);
        }
        public async Task<bool> SaveAll()
        {
            return await _dataContext.SaveChangesAsync() > 0;
        }
    }
}
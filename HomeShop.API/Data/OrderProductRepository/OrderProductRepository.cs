using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeShop.API.Model;
using Microsoft.EntityFrameworkCore;

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

        public async Task<OrderProduct> GetOrderProduct(int i)
        {
            return await _dataContext.OrderProducts.FirstOrDefaultAsync(x => x.OrderproductId == i);
        }

        public async Task<bool> SaveAll()
        {
            return await _dataContext.SaveChangesAsync() > 0;
        }

        public async Task<OrderProduct> GetProduct(int orderId,int productId)
        {
               return   await  _dataContext.OrderProducts.FirstOrDefaultAsync(x => x.OrderId == orderId && x.ProductId == productId);
        }
    }
}
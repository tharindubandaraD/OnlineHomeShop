using System.Threading.Tasks;
using HomeShop.API.Model;

namespace HomeShop.API.Data.OrderRepository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DataContext _dataContext;

        public OrderRepository(DataContext dataContext)
        {           
            _dataContext = dataContext;
        }
        public async Task<Order> addOrder(Order order)
        {
            await _dataContext.Orders.AddAsync(order);
            await _dataContext.SaveChangesAsync();
            return order;
        }
    }
}
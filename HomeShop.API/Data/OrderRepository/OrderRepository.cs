
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeShop.API.Dtos.OrderDto;
using HomeShop.API.Model;
using Microsoft.EntityFrameworkCore;

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

        public async Task<Order> CheckOrderStatus(int userId)
        {   
            Order order = await _dataContext.Orders.Where(s => s.orderStatus == false && s.UserID == userId).FirstOrDefaultAsync();
            return order;    
        }

        public async Task<IEnumerable<GetOrderDetailDto>> GetOrder(int userId)
        {
            var orderDetails = await (from Order in _dataContext.Orders join
                                    OrderProduct in _dataContext.OrderProducts on 
                                    Order.OrderID equals OrderProduct.OrderId join 
                                    product in _dataContext.Products on OrderProduct.ProductId equals product.Id
                                    join photo in _dataContext.Photos on product.Id equals photo.ProductId
                                    where photo.IsMain == true  && Order.orderStatus == false&& Order.UserID == userId 
                                    select new GetOrderDetailDto()
                                    {
                                        OrderId = Order.OrderID,
                                        UserId = Order.UserID,
                                        ProductId = OrderProduct.ProductId,
                                        Quantity = OrderProduct.Quantity,
                                        Price = OrderProduct.Price,
                                        ProductName = product.Name,
                                        ItemLeft = product.Quantity,
                                        Discount = product.Discount,
                                        Url = photo.Url

                                    }).ToListAsync();

                return orderDetails;
            
        }
    }
}
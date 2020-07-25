using AutoMapper;
using HomeShop.DataAccess.Model;
using HomeShop.Entity.Dtos;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeShop.API.Data.OrderRepository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DataContext _dataContext;

        private readonly IMapper _mapper;

        public OrderRepository(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }
        public async Task<OrderDto> AddOrder(OrderDto orderDto)
        {
            Order order = _mapper.Map<OrderDto, Order>(orderDto);
            await _dataContext.Orders.AddAsync(order);
            await _dataContext.SaveChangesAsync();
            return orderDto;
        }

        public async Task<OrderDto> CheckOrderStatus(int userId)
        {
            Order order = await _dataContext.Orders.Where(s => !s.OrderStatus && s.UserID == userId).FirstOrDefaultAsync();

            OrderDto orderDto = _mapper.Map<Order, OrderDto>(order);

            return orderDto;
        }

        public async Task<IEnumerable<GetOrderDetailDto>> GetOrder(int userId)
        {
            var orderDetails = await (from Order in _dataContext.Orders
                                      join
  OrderProduct in _dataContext.OrderProducts on
  Order.OrderID equals OrderProduct.OrderId
                                      join
product in _dataContext.Products on OrderProduct.ProductId equals product.Id
                                      join photo in _dataContext.Photos on product.Id equals photo.ProductId
                                      where photo.IsMain && !Order.OrderStatus && Order.UserID == userId
                                      select new GetOrderDetailDto()
                                      {
                                          OrderId = Order.OrderID,
                                          UserId = Order.UserID,
                                          OrderProductId = OrderProduct.OrderproductId,
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
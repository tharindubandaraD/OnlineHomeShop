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

        /// <summary>Initializes a new instance of the <see cref="OrderRepository" /> class.</summary>
        /// <param name="dataContext">The data context.</param>
        /// <param name="mapper">The mapper.</param>

        public OrderRepository(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }
      
        public void Add<T>(T entity) where T : class
        {
            throw new System.NotImplementedException();
        }


        /// <summary>Adds the order.</summary>
        /// <param name="orderDto">The order dto.</param>
        /// <returns></returns>
        public async Task<OrderDto> AddOrder(OrderDto orderDto)
        {
            Order order = _mapper.Map<Order>(orderDto);
            await _dataContext.Orders.AddAsync(order);

            await _dataContext.SaveChangesAsync();

            foreach (var orderproduct in orderDto.OrderProductDto)
            {
                OrderProduct orderProduct = _mapper.Map<OrderProduct>(orderproduct);
                orderProduct.OrderId = order.OrderID;
                await _dataContext.OrderProducts.AddAsync(orderProduct);

            }     

            return orderDto;
        }

        /// <summary>Checks the order status.</summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        public async Task<OrderDto> CheckOrderStatus(int userId)
        {
            Order order = await _dataContext.Orders.Where(s => s.UserID == userId).FirstOrDefaultAsync();

            OrderDto orderDto = _mapper.Map<Order, OrderDto>(order);

            return orderDto;
        }

        public void Delete<T>(T entity) where T : class
        {
            throw new System.NotImplementedException();
        }

        /// <summary>Gets the order.</summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        public async Task<IEnumerable<GetOrderDetailDto>> GetOrder(int userId)
        {
            var orderDetails = await (from Order in _dataContext.Orders
                                      join
                                         OrderProduct in _dataContext.OrderProducts on
                                         Order.OrderID equals OrderProduct.OrderId
                                      join
                                        product in _dataContext.Products on OrderProduct.ProductId equals product.Id
                                      join photo in _dataContext.Photos on product.Id equals photo.ProductId
                                      where photo.IsMain && Order.UserID == userId
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

        public Task<bool> SaveAll()
        {
            throw new System.NotImplementedException();
        }
    }
}
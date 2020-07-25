using HomeShop.API.Data.OrderProductRepository;
using HomeShop.API.Data.OrderRepository;
using HomeShop.Entity.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HomeShop.API.Business.Order
{
    public class OrderManager : IOrderManager
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderProductRepository _orderProductRepository;
        /// <summary>Initializes a new instance of the <see cref="OrderManager" /> class.</summary>
        /// <param name="orderRepository">The order repository.</param>
        /// <param name="orderProductRepository">The order product repository.</param>
        /// <param name="mapper">The mapper.</param>
        public OrderManager(IOrderRepository orderRepository, IOrderProductRepository orderProductRepository)
        {
            _orderProductRepository = orderProductRepository;
            _orderRepository = orderRepository;
        }
        /// <summary>Adds the order.</summary>
        /// <param name="commonDto">The common dto.</param>
        /// <returns></returns>
        public async Task<OrderDto> AddOrder(CommonDto commonDto)
        {
            OrderDto orderResult = await _orderRepository.CheckOrderStatus(commonDto.UserID);

            if (orderResult == null)
            {
                orderResult.OrderStatus = false;
                orderResult.UserID = commonDto.UserID;

                var orderBusiness = await _orderRepository.AddOrder(orderResult);

                OrderProductDto orderProductobject = new OrderProductDto
                {
                    ProductId = commonDto.ProductId,
                    OrderId = orderBusiness.OrderID,
                    Price = commonDto.Price,
                    Quantity = commonDto.Quantity
                };

                await _orderProductRepository.AddOrderProduct(orderProductobject);


                return orderBusiness;
            }
            else
            {
                OrderProductDto orderProductobject = new OrderProductDto
                {
                    ProductId = commonDto.ProductId,
                    OrderId = orderResult.OrderID,
                    Price = commonDto.Price,
                    Quantity = commonDto.Quantity
                };


                await _orderProductRepository.AddOrderProduct(orderProductobject);

                return orderResult;
            }
        }

        /// <summary>Deletes the order.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<bool> DeleteOrder(int id)
        {
            OrderProductDto orderProduct = await _orderProductRepository.GetOrderProduct(id);

            if (orderProduct == null)
                return false;

            _orderProductRepository.Delete(orderProduct);
            return await _orderProductRepository.SaveAll();
        }

        /// <summary>Gets the order.</summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        public async Task<IEnumerable<GetOrderDetailDto>> GetOrder(int userId)
        {
            IEnumerable<GetOrderDetailDto> getOrderDetail = await _orderRepository.GetOrder(userId);
            return getOrderDetail;
        }
    }
}
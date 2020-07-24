using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HomeShop.API.Data.OrderProductRepository;
using HomeShop.API.Data.OrderRepository;
using HomeShop.Entity.Dtos;

namespace HomeShop.API.Business.Order
{
    public class OrderManager : IOrderManager
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly IOrderProductRepository _orderProductRepository;
        public OrderManager(IOrderRepository orderRepository, IOrderProductRepository orderProductRepository, IMapper mapper)
        {
           _orderProductRepository = orderProductRepository;
            _mapper = mapper;
            _orderRepository = orderRepository;
        }
        public async Task<OrderDto> addOrder(CommonDto commonDto)
        {
            OrderDto orderResult = await _orderRepository.CheckOrderStatus(commonDto.UserID);

            if(orderResult == null)
            {

                #pragma warning disable S2259 // Null pointers should not be dereferenced
                orderResult.orderStatus = false;
                #pragma warning restore S2259 // Null pointers should not be dereferenced
                orderResult.UserID = commonDto.UserID;
                
                    var orderBusiness = await _orderRepository.addOrder(orderResult);

                    OrderProductDto orderProductobject = new OrderProductDto{
                            ProductId = commonDto.ProductId,
                            OrderId = orderBusiness.OrderID,
                            Price = commonDto.Price,
                            Quantity = commonDto.Quantity
                    };
                    
                    await _orderProductRepository.addOrderProduct(orderProductobject);
            

                    return orderBusiness;
            }
            else
            {
                    OrderProductDto orderProductobject = new OrderProductDto{
                            ProductId = commonDto.ProductId,
                            OrderId = orderResult.OrderID,
                            Price = commonDto.Price,
                            Quantity = commonDto.Quantity
                    };

                
                    await _orderProductRepository.addOrderProduct(orderProductobject);
            
                    return orderResult;
            }
        }

        public async Task<bool> deleteOrder(int id)
        {
            OrderProductDto orderProduct = await _orderProductRepository.GetOrderProduct(id);

            if(orderProduct == null)
                return false;
                        
            _orderProductRepository.Delete(orderProduct);
            return await _orderProductRepository.SaveAll();
        }

        public async Task<IEnumerable<GetOrderDetailDto>> getOrder(int userId)
        {
            IEnumerable<GetOrderDetailDto> getOrderDetail = await _orderRepository.GetOrder(userId);
            return getOrderDetail;
        }
    }
}
using System.Threading.Tasks;
using AutoMapper;
using HomeShop.API.Data.OrderProductRepository;
using HomeShop.API.Data.OrderRepository;
using HomeShop.API.Dtos.CommonDto;
using HomeShop.API.Dtos.OrderDto;
using HomeShop.API.Dtos.OrderProductDto;
using HomeShop.API.Model;

namespace HomeShop.API.Business._Order
{
    public class OrderBusinessLayer : IOrderBusinessLayer
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly IOrderProductRepository _orderProductRepository;
        public OrderBusinessLayer(IOrderRepository orderRepository, IOrderProductRepository orderProductRepository, IMapper mapper)
        {
           _orderProductRepository = orderProductRepository;
            _mapper = mapper;
            _orderRepository = orderRepository;
        }
        public async Task<Order> addOrder(CommonDto commonDto)
        {
            Order orderResult = await _orderRepository.CheckOrderStatus(commonDto.UserID);

            if(orderResult == null)
            {
                  OrderDto orderDto = new OrderDto
                    {
                        orderStatus = false,
                        UserID = commonDto.UserID
                    };

                    Order OrderToCreate = _mapper.Map<Order>(orderDto);
                    var orderBusiness = await _orderRepository.addOrder(OrderToCreate);

                    OrderProductDto orderProductobject = new OrderProductDto{
                            ProductId = commonDto.ProductId,
                            OrderId = orderBusiness.OrderID,
                            Price = commonDto.Price,
                            Quantity = commonDto.Quantity
                    };

                    OrderProduct orderProduct = _mapper.Map<OrderProduct>(orderProductobject);
                    var orderProductRepository = await _orderProductRepository.addOrderProduct(orderProduct);
            

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

                    OrderProduct orderProduct = _mapper.Map<OrderProduct>(orderProductobject);
                    var orderProductRepository = await _orderProductRepository.addOrderProduct(orderProduct);
            
                    return orderResult;
            }
        }
    }
}
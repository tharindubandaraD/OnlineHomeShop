using System;
using System.Collections.Generic;
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
                OrderProduct orderProductFromRepo = await _orderProductRepository.GetProduct(orderResult.OrderID, commonDto.ProductId);
                if(orderProductFromRepo != null)
                {
                       OrderProductDto orderProductDto = new OrderProductDto{
                            OrderProductId = orderProductFromRepo.OrderproductId,
                            ProductId = commonDto.ProductId,
                            OrderId = orderResult.OrderID,
                            Price = commonDto.Price,
                            Quantity = commonDto.Quantity + orderProductFromRepo.Quantity
                    };

                    _mapper.Map(orderProductDto,orderProductFromRepo);

                   if(await _orderProductRepository.SaveAll())
                         return orderResult;

                    throw new Exception($"Updating failed");
                }
                else
                {

                 OrderProductDto orderProductobject = new OrderProductDto{
                            ProductId = commonDto.ProductId,
                            OrderId = orderResult.OrderID,
                            Price = commonDto.Price,
                            Quantity = commonDto.Quantity
                    };

                    OrderProduct orderProductItem = _mapper.Map<OrderProduct>(orderProductobject);
                    var orderProductRepository = await _orderProductRepository.addOrderProduct(orderProductItem);
            
                    return orderResult;
                }
            }
         }
        

        public async Task<bool> deleteOrder(int id)
        {
            OrderProduct orderProduct = await _orderProductRepository.GetOrderProduct(id);

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
using System.Threading.Tasks;
using AutoMapper;
using HomeShop.API.Data.OrderRepository;
using HomeShop.API.Dtos.OrderDto;
using HomeShop.API.Model;

namespace HomeShop.API.Business._Order
{
    public class OrderBusinessLayer : IOrderBusinessLayer
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        public OrderBusinessLayer(IOrderRepository orderRepository, IMapper mapper)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
        }
        public async Task<Order> addOrder(OrderDto orderDto)
        {
             Order OrderToCreate = _mapper.Map<Order>(orderDto);
             var orderBusiness = await _orderRepository.addOrder(OrderToCreate);
             return orderBusiness;
        }
    }
}
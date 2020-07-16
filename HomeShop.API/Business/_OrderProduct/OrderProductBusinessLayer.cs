using System.Threading.Tasks;
using AutoMapper;
using HomeShop.API.Data.OrderProductRepository;
using HomeShop.API.Dtos.OrderProductDto;
using HomeShop.API.Model;

namespace HomeShop.API.Business._OrderProduct
{
    public class OrderProductBusinessLayer : IOrderProductBusinessLayer
    {
        private readonly IOrderProductRepository _orderProductRepository;
        private readonly IMapper _mapper;
        public OrderProductBusinessLayer(IOrderProductRepository orderProductRepository, IMapper mapper)
        {
            _mapper = mapper;
            _orderProductRepository = orderProductRepository;

        }
        public async Task<OrderProduct> SetOrderProduct(OrderProductDto orderProductDto)
        {
            OrderProduct orderProduct = _mapper.Map<OrderProduct>(orderProductDto);
            var orderProductRepository = await _orderProductRepository.addOrderProduct(orderProduct);
            return orderProductRepository;
        }
    }
}
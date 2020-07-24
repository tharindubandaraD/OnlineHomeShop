using AutoMapper;
using HomeShop.DataAccess.Model;
using HomeShop.Entity.Dtos;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace HomeShop.API.Data.OrderProductRepository
{
    public class OrderProductRepository : IOrderProductRepository
    {
        private readonly DataContext _dataContext;

        private readonly IMapper _mapper;

        public OrderProductRepository(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }
        public async Task<OrderProductDto> addOrderProduct(OrderProductDto orderProductDto)
        {
            OrderProduct orderProduct = _mapper.Map<OrderProductDto, OrderProduct>(orderProductDto);
            await _dataContext.OrderProducts.AddAsync(orderProduct);
            await _dataContext.SaveChangesAsync();
            return orderProductDto;
        }


        public void Delete<T>(T entity) where T : class
        {
            _dataContext.Remove(entity);
        }

        public async Task<OrderProductDto> GetOrderProduct(int i)
        {
            OrderProduct orderProduct = await _dataContext.OrderProducts.FirstOrDefaultAsync(x => x.OrderproductId == i);
            return _mapper.Map<OrderProduct, OrderProductDto>(orderProduct);
        }

        public async Task<bool> SaveAll()
        {
            return await _dataContext.SaveChangesAsync() > 0;
        }
    }
}
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

        /// <summary>Initializes a new instance of the <see cref="OrderProductRepository" /> class.</summary>
        /// <param name="dataContext">The data context.</param>
        /// <param name="mapper">The mapper.</param>
        public OrderProductRepository(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }
        /// <summary>Adds the order product.</summary>
        /// <param name="orderProductDto">The order product dto.</param>
        /// <returns></returns>
        public async Task<OrderProductDto> AddOrderProduct(OrderProductDto orderProductDto)
        {
            OrderProduct orderProduct = _mapper.Map<OrderProductDto, OrderProduct>(orderProductDto);
            await _dataContext.OrderProducts.AddAsync(orderProduct);
            await _dataContext.SaveChangesAsync();
            return orderProductDto;
        }


        /// <summary>Deletes the specified entity.</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity">The entity.</param>
        public void Delete<T>(T entity) where T : class
        {
            _dataContext.Remove(entity);
        }

        /// <summary>Gets the order product.</summary>
        /// <param name="i">The i.</param>
        /// <returns></returns>
        public async Task<OrderProductDto> GetOrderProduct(int i)
        {
            OrderProduct orderProduct = await _dataContext.OrderProducts.FirstOrDefaultAsync(x => x.OrderproductId == i);
            return _mapper.Map<OrderProduct, OrderProductDto>(orderProduct);
        }

        /// <summary>Saves all.</summary>
        /// <returns></returns>
        public async Task<bool> SaveAll()
        {
            return await _dataContext.SaveChangesAsync() > 0;
        }
    }
}
using HomeShop.API.Data.OrderProductRepository;
using HomeShop.API.Data.OrderRepository;
using HomeShop.DataAccess.UnitofWork;
using HomeShop.Entity.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HomeShop.API.Business.Order
{
    public class OrderManager : IOrderManager
    {
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>Initializes a new instance of the <see cref="OrderManager" /> class.</summary>
        /// <param name="orderRepository">The order repository.</param>
        /// <param name="orderProductRepository">The order product repository.</param>
        /// <param name="mapper">The mapper.</param>
        public OrderManager(IUnitOfWork unitOfWork)
        {           
           _unitOfWork = unitOfWork;
        }
        /// <summary>Adds the order.</summary>
        /// <param name="commonDto">The common dto.</param>
        /// <returns></returns>
        public async Task<OrderDto> AddOrder(OrderDto orderDto)
        {
            try
            {
                        
                            
                OrderDto orderResult = await _unitOfWork.OrderRepository.AddOrder(orderDto);
            
              //  await _unitOfWork.OrderProductRepository.AddOrderProduct(orderProductDto);

                _unitOfWork.Commit();
                return null;
              
            }
            catch( Exception e )
            {
                _unitOfWork.Rollback();
                return null;
            }
        }

        /// <summary>Deletes the order.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<bool> DeleteOrder(int id)
        {
            OrderProductDto orderProduct = await _unitOfWork.OrderProductRepository.GetOrderProduct(id);

            if (orderProduct == null)
                return false;

            _unitOfWork.OrderProductRepository.Delete(orderProduct);
            return await _unitOfWork.OrderProductRepository.SaveAll();
        }

        /// <summary>Gets the order.</summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        public async Task<IEnumerable<GetOrderDetailDto>> GetOrder(int userId)
        {
            IEnumerable<GetOrderDetailDto> getOrderDetail = await _unitOfWork.OrderRepository.GetOrder(userId);
            return getOrderDetail;
        }
    }
}
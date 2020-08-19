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
        private readonly IEmailSender _emailSender;

        /// <summary>Initializes a new instance of the <see cref="OrderManager" /> class.</summary>
        /// <param name="orderRepository">The order repository.</param>
        /// <param name="orderProductRepository">The order product repository.</param>
        /// <param name="mapper">The mapper.</param>
        public OrderManager(IUnitOfWork unitOfWork, IEmailSender emailSender)
        {           
           _unitOfWork = unitOfWork;
           _emailSender = emailSender;
        }
        /// <summary>Adds the order.</summary>
        /// <param name="commonDto">The common dto.</param>
        /// <returns></returns>
        public async Task<OrderDto> AddOrder(OrderDto orderDto)
        {
            try
            {
                await _unitOfWork.OrderRepository.AddOrder(orderDto);
                _unitOfWork.Commit();
                sendMail(orderDto);
                return null;
              
            }
            catch( Exception e )
            {
                _unitOfWork.Rollback();
                return null;
            }
        }
        private void sendMail(OrderDto orderDto)
        {
            string emailbody;

            emailbody = "<br><br><table border='1'>" +
            "<tr>" +
             "<th>Full Name</th>" +
             "<th>Address</th>" +
             "<th>Discount</th>" +
             "<th>Total</th>" +
            "</tr>" +
            "<tr>" +
             "<td>" + orderDto.FullName + "</td>" +
             "<td>" + orderDto.Address + "</td>" +
             "<td>" + orderDto.Discount + "</td>" +
             "<td>" + orderDto.GrandTotal + "</td>" +
            "</tr>" +
            "</table><br><br>" + "Item Purchase";

            List<OrderProductDto> orderProductDto = orderDto.OrderProductDto;

            for (int i = 0; i < orderProductDto.Count; i++)
            {
#pragma warning disable S1643 // Strings should not be concatenated using '+' in a loop
                emailbody +=   "<table>" +
                                            "<tr>" +
                                            "<td>" + "Name: " + orderProductDto[i].Name + "</td>" +
                                            "<td>" + " Price: " + orderProductDto[i].Price + "</td>" +
                                            "</tr>" +
                                            "</table>";
#pragma warning restore S1643 // Strings should not be concatenated using '+' in a loop
            }             
            
            _emailSender.Send(orderDto.Email , "Home Shop - Bill", emailbody);
           
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

        public async Task<IEnumerable<OrderInformDto>> GetOrderInfromation(int UserId)
        {
            return await _unitOfWork.OrderRepository.GetOrderInfromation(UserId);            
        }
    }
}
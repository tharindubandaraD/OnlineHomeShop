using System.Collections.Generic;

namespace HomeShop.Entity.Dtos
{
    public class OrderDto
    {
        public int OrderID { get; set; }
        public bool orderStatus { get; set; }
        public int UserID { get; set; }      
        public UserForOrderDto User { get; set; }      
        public ICollection<OrderProductDto> OrderProduct { get; set; }
    }

}
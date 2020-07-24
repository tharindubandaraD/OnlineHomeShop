using System.Collections.Generic;

namespace HomeShop.DataAccess.Model
{
    public class Order
    {
        public int OrderID { get; set; }    
        public bool orderStatus { get; set; }
        public User User { get; set; }              
        public int UserID { get; set; }        
        public ICollection<OrderProduct> OrderProduct { get; set; }
    }
}
using System;
using System.Collections.Generic;

namespace HomeShop.DataAccess.Model
{
    public class Order
    {
        public int OrderID { get; set; }
        public bool OrderStatus { get; set; }
        public User User { get; set; }
        public int UserID { get; set; }
        public DateTime OrderDate { get; set; }
        public int Total { get; set; }
        public ICollection<OrderProduct> OrderProduct { get; set; }
    }
}
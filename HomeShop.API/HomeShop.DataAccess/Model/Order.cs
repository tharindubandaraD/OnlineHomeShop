using System;
using System.Collections.Generic;

namespace HomeShop.DataAccess.Model
{
    public class Order
    {
        public int OrderID { get; set; }
        public User User { get; set; }
        public int UserID { get; set; }
        public string Address { get; set; }
        public string FullName { get; set; }
        public DateTime OrderDate { get; set; }
        public int Total { get; set; }
        public int Discount { get; set; }
        public int GrandTotal { get; set; }
        public List<OrderProduct> OrderProduct { get; set; }
    }
}
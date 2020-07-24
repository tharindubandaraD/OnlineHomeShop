using System.Collections.Generic;
using HomeShop.DataAccess.Model;

namespace HomeShop.DataAccess.Model
{
    public class OrderProduct
    {
        public int OrderproductId { get; set; }             
        public int Quantity { get; set; }     
        public double Price { get; set; }   
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public Order Order { get; set; }
        public int OrderId { get; set; }
    }
}
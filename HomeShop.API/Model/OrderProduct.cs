using System.Collections.Generic;

namespace HomeShop.API.Model
{
    public class OrderProduct
    {
        public int OrderproductId { get; set; }             
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
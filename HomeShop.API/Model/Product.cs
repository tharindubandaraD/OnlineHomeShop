using System.Collections.Generic;

namespace HomeShop.API.Model
{
    public class Product
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public int Quantity { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public double Discount { get; set; }
        public ICollection<Photo> Photos { get; set; }
    }
}
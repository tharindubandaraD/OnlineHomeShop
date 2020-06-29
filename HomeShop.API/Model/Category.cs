using System.Collections.Generic;

namespace HomeShop.API.Model
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
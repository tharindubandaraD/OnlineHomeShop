using System.Collections.Generic;

namespace HomeShop.API.Model
{
    public class Brand
    {
        public int BrandId { get; set; }
        public string  BrandName { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
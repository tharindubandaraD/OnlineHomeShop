using System.Collections.Generic;
using HomeShop.API.Model;

namespace HomeShop.API.Dtos
{
    public class ProductDetailDto
    {
        public int Id { get; set; }

        public string Category { get; set; }

        public int Quantity { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public double Discount { get; set; }
        
        public string  PhotoUrl { get; set; }

        public  ICollection<PhotosForDetailDto> Photos { get; set; }    

    }
}
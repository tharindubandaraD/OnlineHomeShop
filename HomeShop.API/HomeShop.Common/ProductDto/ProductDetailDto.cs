using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace HomeShop.Entity.Dtos
{
    [ExcludeFromCodeCoverage]
    public class ProductDetailDto
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }

        public int Quantity { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public double Discount { get; set; }

        public string PhotoUrl { get; set; }

        public ICollection<PhotosForDetailDto> Photos { get; set; }

    }
}
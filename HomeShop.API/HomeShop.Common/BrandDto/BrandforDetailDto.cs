using System.Collections.Generic;

namespace HomeShop.Entity.Dtos
{
    public class BrandforDetailDto
    {
        public string BrandName { get; set; }
        public ICollection<ProductListDto> Products { get; set; }
    }
}
using System.Collections.Generic;
using HomeShop.API.Model;

namespace HomeShop.API.Dtos
{
    public class CategoryForDetailDto
    {
        public int CategoryId { get;set;}
        public string Name { get; set; }
        public ICollection<ProductListDto> Products { get; set; }
        
    }
}
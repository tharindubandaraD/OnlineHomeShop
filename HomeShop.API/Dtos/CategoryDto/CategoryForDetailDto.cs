using System.Collections.Generic;
using HomeShop.API.Model;

namespace HomeShop.API.Dtos
{
    public class CategoryForDetailDto
    {
        public string CategoryName { get;set;}
        public string ProductName { get; set; }           
        public string PhotoUrl { get; set; }
        public double Price { get; set; }
        
    }
}
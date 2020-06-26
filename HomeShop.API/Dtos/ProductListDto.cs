using HomeShop.API.Model;

namespace HomeShop.API.Dtos
{
    public class ProductListDto
    {
         public int Id { get; set; }

        public string Category { get; set; }

        public string Name { get; set; }      

        public double Price { get; set; }

        public double Discount { get; set; }

        public int PhotoId { get; set; }
    }
}
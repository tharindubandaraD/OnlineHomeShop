namespace HomeShop.Entity.Dtos
{
    public class ProductListDto
    {
        public int Id { get; set; }     
     
        public string Name { get; set; }       

        public double Price { get; set; }

        public double Discount { get; set; }
        
        public string  PhotoUrl { get; set; }
       

    }
}
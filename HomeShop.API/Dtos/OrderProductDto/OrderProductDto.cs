namespace HomeShop.API.Dtos.OrderProductDto
{
    public class OrderProductDto
    {
        public int OrderProductId { get; set; }
        public int ProductId { get; set; }  
        public int OrderId { get; set; }  
        public decimal Price { get; set; }   
        public int Quantity { get; set; }
    }
}
namespace HomeShop.API.Dtos.OrderDto
{
    public class GetOrderDetailDto
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }       
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int ItemLeft { get; set; }
        public double Price { get; set; }
        public string ProductName { get; set; }
        public double Discount { get; set; }
        public string Url { get; set; }
    }
}
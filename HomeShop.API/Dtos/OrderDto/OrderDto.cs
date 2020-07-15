namespace HomeShop.API.Dtos.OrderDto
{
    public class OrderDto
    {
        public int OrderID { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public bool orderStatus { get; set; }
        public int UserID { get; set; }
        public int OrderProductId { get; set; }
    }
}
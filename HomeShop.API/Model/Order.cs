namespace HomeShop.API.Model
{
    public class Order
    {
        public int OrderID { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public bool orderStatus { get; set; }
        public User User { get; set; }        
        public int UserID { get; set; }
        public OrderProduct OrderProducts { get; set; }
        public int OrderProductId { get; set; }
    }
}
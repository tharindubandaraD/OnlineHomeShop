namespace HomeShop.Entity.Dtos
{
    public class OrderProductDto
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public double Discount { get; set; }
        public int OrderId { get; set; }
    }
}
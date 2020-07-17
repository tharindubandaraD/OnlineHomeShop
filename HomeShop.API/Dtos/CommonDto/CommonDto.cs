namespace HomeShop.API.Dtos.CommonDto
{
    public class CommonDto
    {
        public int OrderId { get; set; }     

        public bool OrderStatus { get; set; }
        
        public int UserID { get; set; }

        public int  OrderProductId { get; set; }

        public int Quantity { get; set; }

        public int  Price { get; set; }

        public int ProductId { get; set; }

        
    }
}
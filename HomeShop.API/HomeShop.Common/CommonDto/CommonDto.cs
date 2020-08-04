using System;

namespace HomeShop.Entity.Dtos
{
    public class CommonDto
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public int Total { get; set; }
        public string Address { get; set; }
        public string FullName { get; set; }
        public int OrderProductId { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public int ProductId { get; set; }


    }
}
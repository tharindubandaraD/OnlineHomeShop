using System;

namespace HomeShop.Entity.Dtos
{
    public class OrderInformDto
    {
        public int OrderID { get; set; }
        public DateTime  OrderDate { get; set; }
        public int Total { get; set; }
        public string Address { get; set; }
        public int Discount { get; set; }
        public int GrandTotal { get; set; }
        public bool Expanded { get; set; } = false;
    }
}

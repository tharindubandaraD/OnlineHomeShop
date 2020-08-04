using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HomeShop.Entity.Dtos
{
    public class OrderDto
    {
        [Key]
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public int Total { get; set; }
        public string Address { get; set; }
        public string FullName { get; set; }
        public List<OrderProductDto> OrderProductDto { get; set; }

    }

}
using System;
using System.Collections.Generic;


namespace HomeShop.API.Model
{
    public class Photo
    {
        public int Id { get; set; }

        public string  Url { get; set; }

        public string Description{ get; set; }

        public DateTime DateAdded { get; set; }

        public bool IsMain { get; set; }

        public int PublicId { get; set; }

        public Product Product { get; set; }

        public int ProductId { get; set; }
      
    }
}
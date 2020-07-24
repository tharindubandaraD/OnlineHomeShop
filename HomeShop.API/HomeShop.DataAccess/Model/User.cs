using System;
using System.Collections.Generic;

namespace HomeShop.DataAccess.Model
{
    public class User
    {

        public int Id { get; set; }

        public string Username { get; set; }

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }

        public string Gender { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string KnownAs { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public ICollection<Order> Orders { get; set; }

    }
}
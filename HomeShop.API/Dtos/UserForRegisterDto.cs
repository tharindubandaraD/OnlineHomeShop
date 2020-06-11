using System;

namespace HomeShop.API.Dtos
{
    public class UserForRegisterDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }
        public string KnownAs { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastActive { get; set; }
        
    }
}
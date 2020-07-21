using System;
using System.ComponentModel.DataAnnotations;

namespace HomeShop.API.Dtos
{
    public class UserForRegisterDto
    {
        //data annotations
        [Required]
        public string UserName { get; set; }
        
        [Required]
        [StringLength(8, MinimumLength= 4, ErrorMessage= "Password should be between 4 and 8 characters")]
        public string Password { get; set; }
        public string Gender { get; set; }
        public string KnownAs { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        
    }
}
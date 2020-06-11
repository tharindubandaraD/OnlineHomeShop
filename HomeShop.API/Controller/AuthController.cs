using System.Threading.Tasks;
using HomeShop.API.Data;
using HomeShop.API.Dtos;
using HomeShop.API.Model;
using Microsoft.AspNetCore.Mvc;

namespace HomeShop.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]

    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;
        public AuthController(IAuthRepository repo)
        {          
            _repo = repo;
        }

         [HttpPost("register")]
        //we are using DTO to parse into register method 
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDtos)
        {            
            //validate request 
            userForRegisterDtos.UserName = userForRegisterDtos.UserName.ToLower();

            if (await _repo.UserExists(userForRegisterDtos.UserName))
                return BadRequest("User already exisits");
           

            var userToCreate = new User 
            {
                Username = userForRegisterDtos.UserName
            };
            var createdUser = await _repo.Register(userToCreate, userForRegisterDtos.Password);        

            return StatusCode(201);

        }

    }
}
using HomeShop.API.Business;
using HomeShop.Entity.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HomeShop.API.Controller
{
    [Route("api/[controller]")]
    //without this the dont know from where request is comming from  - model state 
    [ApiController]

    public class AuthController : ControllerBase
    {
        private readonly IAuthManager _authbusiness;
        public AuthController(IAuthManager authBusinessLayer)
        {
            _authbusiness = authBusinessLayer;
        }

        /// <summary>Registers the specified user for register dtos.</summary>
        /// <param name="userForRegisterDtos">The user for register dtos.</param>
        /// <returns></returns>
        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDtos)
        {
            //validate request 
            if (!await _authbusiness.Register(userForRegisterDtos))
                return BadRequest("User already exisits");

            return StatusCode(201);

        }

        /// <summary>Logins the specified user for login dtos.</summary>
        /// <param name="userForLoginDtos">The user for login dtos.</param>
        /// <returns></returns>
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginDtos userForLoginDtos)
        {
            var userForLogin = await _authbusiness.Login(userForLoginDtos.Username.ToLower(), userForLoginDtos.Password);

            if (userForLogin.Token == null)
                return Unauthorized();

            return Ok(new
            {
                token = userForLogin.Token
            });

        }

        [Microsoft.AspNetCore.Authorization.Authorize]
        [HttpGet("user/{id}")]
        public async Task<IActionResult> GetUser(int id) 
        {
            var user = await  _authbusiness.GetUser(id);
            return Ok(user);
        }

     

    }
}
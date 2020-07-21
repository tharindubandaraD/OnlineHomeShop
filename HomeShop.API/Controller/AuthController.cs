using System.Threading.Tasks;
using AutoMapper;
using HomeShop.API.Business;
using HomeShop.API.Dtos;
using HomeShop.API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace HomeShop.API.Controller
{
    [Route("api/[controller]")]
    //without this the dont know from where request is comming from  - model state 
    [ApiController]

    public class AuthController : ControllerBase
    {
        private readonly IAuthBusinessLayer _authbusiness;
        private readonly IConfiguration _config;
        public AuthController(IConfiguration config, IAuthBusinessLayer authBusinessLayer)
        {           
            _config = config;
            _authbusiness = authBusinessLayer;
        }

        [HttpPost("register")]
        //we are using DTO to parse into register method 
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDtos)
        {
            //validate request 
            if (!await _authbusiness.Register(userForRegisterDtos))
                return BadRequest("User already exisits");

            return Ok();

        }

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

    }
}
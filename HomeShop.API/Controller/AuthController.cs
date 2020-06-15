using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using HomeShop.API.Data;
using HomeShop.API.Dtos;
using HomeShop.API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace HomeShop.API.Controller
{
    [Route("api/[controller]")]
    //without this the dont know from where request is comming from  - model state 
    [ApiController]

    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;
        private readonly IConfiguration _config;
        public AuthController(IAuthRepository repo, IConfiguration config)
        {
            _config = config;
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

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginDtos userForLoginDtos)
        {
            var userFromRepo = await _repo.Login(userForLoginDtos.Username.ToLower(), userForLoginDtos.Password);

            if (userFromRepo == null)
                return Unauthorized();

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userFromRepo.Id.ToString()),
                new Claim(ClaimTypes.Name , userFromRepo.Username)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);           

            return Ok(new
            {
                token = tokenHandler.WriteToken(token)               
            });

        }

    }
}
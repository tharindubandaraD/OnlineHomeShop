using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using System.Text;
using HomeShop.API.Data;
using HomeShop.API.Dtos;
using Microsoft.IdentityModel.Tokens;
using System.Threading.Tasks;
using System.Collections;
using HomeShop.API.Model;

namespace HomeShop.API.Business
{
    public class AuthBusinessLayer : IAuthBusinessLayer
    {
        private readonly IAuthRepository _authRepository;
        private readonly IConfiguration _configuration;
        public AuthBusinessLayer(IAuthRepository authRepository, IConfiguration configuration)
        {
            _configuration = configuration;
            _authRepository = authRepository;

        }
        public async Task<UserForLoginDtos> Login(string username, string password)
        {
            var userFromRepo = await _authRepository.Login(username.ToLower(), password);

            if (userFromRepo == null)
                return null;

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userFromRepo.Id.ToString()),
                new Claim(ClaimTypes.Name , userFromRepo.Username)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            string serializetoken = tokenHandler.WriteToken(token);

            return new UserForLoginDtos
            {
               Token = serializetoken
            };
        }

        public async Task<bool> Register(UserForRegisterDto userForRegisterDto)
        {
            userForRegisterDto.UserName = userForRegisterDto.UserName.ToLower();

            if(await _authRepository.UserExists(userForRegisterDto.UserName))
                return false;

             var userToCreate = new User
            {
               Username = userForRegisterDto.UserName
            };
            var createdUser = await _authRepository.Register(userToCreate, userForRegisterDto.Password);

            return true;
            
        }

       
    }
}
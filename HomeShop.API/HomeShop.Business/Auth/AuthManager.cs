using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using System.Text;
using HomeShop.API.Data;
using HomeShop.Entity.Dtos;
using Microsoft.IdentityModel.Tokens;
using System.Threading.Tasks;
using System.Collections;

namespace HomeShop.API.Business
{
    public class AuthManager : IAuthManager
    {
        private readonly IAuthRepository _authRepository;
        private readonly IConfiguration _configuration;
        public AuthManager(IAuthRepository authRepository, IConfiguration configuration)
        {
            _configuration = configuration;
            _authRepository = authRepository;

        }
        //get user
        public async Task<UserForLoginDtos> Login(string username, string password)
        {
            var userFromRepo = await _authRepository.Login(username.ToLower(), password);

            if (userFromRepo == null)
                //return proper status code
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

            UserForLoginDtos userForLogin = _mapper.Map<UserForLoginDtos>(userFromRepo);

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

            var createdUser = await _authRepository.Register(userForRegisterDto, userForRegisterDto.Password);

            return true;
            
        }

       
    }
}
using HomeShop.API.Data;
using HomeShop.DataAccess.UnitofWork;
using HomeShop.Entity.Dtos;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HomeShop.API.Business
{
    public class AuthManager : IAuthManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        public AuthManager(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _configuration = configuration;
            _unitOfWork = unitOfWork;

        }

        /// <summary>Gets the user.</summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<UserForOrderDto> GetUser(int Id)
        {
            return await _unitOfWork.AuthRepository.GetUser(Id);
        }

        /// <summary>Logins the specified username.</summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        public async Task<UserForLoginDtos> Login(string username, string password)
        {
            var userFromRepo = await _unitOfWork.AuthRepository.Login(username.ToLower(), password);

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

        /// <summary>Registers the specified user for register dto.</summary>
        /// <param name="userForRegisterDto">The user for register dto.</param>
        /// <returns></returns>
        public async Task<bool> Register(UserForRegisterDto userForRegisterDto)
        {
           
            userForRegisterDto.UserName = userForRegisterDto.UserName.ToLower();

            if (await _unitOfWork.AuthRepository.UserExists(userForRegisterDto.UserName))
                return false;

            await _unitOfWork.AuthRepository.Register(userForRegisterDto, userForRegisterDto.Password);

            _unitOfWork.Commit();

            return true;

        }


    }
}
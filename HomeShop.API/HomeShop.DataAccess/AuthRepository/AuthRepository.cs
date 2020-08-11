using AutoMapper;
using HomeShop.DataAccess.Model;
using HomeShop.Entity.Dtos;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace HomeShop.API.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
       

        public AuthRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;           
        }

        /// <summary>Logins the specified username.</summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        public async Task<UserForLoginDtos> Login(string username, string password)
        {
            User user = await _context.Users.FirstOrDefaultAsync(x => x.Username == username);

            if (user == null)
                return null;
            ///<summary>this will return true or false</summary>
            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;


            return _mapper.Map<UserForLoginDtos>(user);

        }

        /// <summary>Registers the specified user dto.</summary>
        /// <param name="userDto">The user dto.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        public async Task<UserForRegisterDto> Register(UserForRegisterDto userDto, string password)
        {
            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

            User user = _mapper.Map<UserForRegisterDto, User>(userDto);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            ///<summary>add changes to database</summary>
            await _context.Users.AddAsync(user);


            ///<summary>returning the user</summary>
            return userDto;
        }

        /// <summary>Users the exists.</summary>
        /// <param name="username">The username.</param>
        /// <returns></returns>
        public async Task<bool> UserExists(string username)
        {
            if (await _context.Users.AnyAsync(x => x.Username == username))
                return true;

            return false;
        }

        /// <summary>Verifies the password hash.</summary>
        /// <param name="password">The password.</param>
        /// <param name="passwordHash">The password hash.</param>
        /// <param name="passwordSalt">The password salt.</param>
        /// <returns></returns>
        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            ///<summary>same as create password hash pass passwordsalt</summary>
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    ///<summary>compair both computed and password hashes </summary>
                    if (computedHash[i] != passwordHash[i]) return false;
                }
            }
            return true;
        }
        /// <summary>Creates the password hash.</summary>
        /// <param name="password">The password.</param>
        /// <param name="passwordHash">The password hash.</param>
        /// <param name="passwordSalt">The password salt.</param>
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using var hmac = new System.Security.Cryptography.HMACSHA512();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

        }

        /// <summary>Gets the user.</summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task<UserForOrderDto> GetUser(int Id)
        {
            User user = await _context.Users.FirstOrDefaultAsync(x => x.Id == Id);
            return _mapper.Map<UserForOrderDto>(user);
        }
    }
}
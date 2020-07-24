using System.Threading.Tasks;
using HomeShop.Entity.Dtos;

namespace HomeShop.API.Data
{
    public interface IAuthRepository
    {
        Task<UserForRegisterDto> Register(UserForRegisterDto userDto, string password);
        Task<UserForLoginDtos> Login(string username, string password);
        Task<bool> UserExists(string username);          
    }
}
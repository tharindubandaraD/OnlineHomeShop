using System.Threading.Tasks;
using HomeShop.Entity.Dtos;

namespace HomeShop.API.Business
{
    public interface IAuthManager
    {      
        Task<bool> Register(UserForRegisterDto userForRegisterDto);         
        Task<UserForLoginDtos> Login(string username, string password);
    }
}
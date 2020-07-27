using HomeShop.Entity.Dtos;
using System.Threading.Tasks;

namespace HomeShop.API.Business
{
    public interface IAuthManager
    {
        Task<bool> Register(UserForRegisterDto userForRegisterDto);
        Task<UserForLoginDtos> Login(string username, string password);
        Task<UserForOrderDto> GetUser(int Id);
       
    }
}
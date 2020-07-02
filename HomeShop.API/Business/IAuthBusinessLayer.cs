using System.Threading.Tasks;
using HomeShop.API.Dtos;
using HomeShop.API.Model;

namespace HomeShop.API.Business
{
    public interface IAuthBusinessLayer
    {      
        Task<bool> Register(UserForRegisterDto userForRegisterDto);         
        Task<UserForLoginDtos> Login(string username, string password);
    }
}
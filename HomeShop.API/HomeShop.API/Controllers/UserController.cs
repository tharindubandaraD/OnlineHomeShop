using HomeShop.API.Business;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HomeShop.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IAuthManager _authbusiness;
        public UserController(IAuthManager authBusinessLayer)
        {
            _authbusiness = authBusinessLayer;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _authbusiness.GetUser(id);
            return Ok(user);
        }
    }
}

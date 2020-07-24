using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HomeShop.API.Data.BrandRepository;
using HomeShop.Entity.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HomeShop.API.Controller
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;
        public BrandController(IBrandRepository brandRepository, IMapper mapper)
        {
            this._mapper = mapper;
            _brandRepository = brandRepository;
        }

        [HttpGet]
        public async Task<IActionResult> getBrands()
        {
            var categoryRepository = await _brandRepository.getBrands();
            var mapcategoryrepository = _mapper.Map<IEnumerable<BrandforDetailDto>>(categoryRepository);
            return Ok(mapcategoryrepository);
        }
    }
}
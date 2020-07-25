using AutoMapper;
using HomeShop.API.Data.BrandRepository;
using HomeShop.Entity.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HomeShop.API.Controller
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;
        /// <summary>Initializes a new instance of the <see cref="BrandController" /> class.</summary>
        /// <param name="brandRepository">The brand repository.</param>
        /// <param name="mapper">The mapper.</param>
        public BrandController(IBrandRepository brandRepository, IMapper mapper)
        {
            this._mapper = mapper;
            _brandRepository = brandRepository;
        }

        /// <summary>Gets the brands.</summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetBrands()
        {
            var categoryRepository = await _brandRepository.GetBrands();
            var mapcategoryrepository = _mapper.Map<IEnumerable<BrandforDetailDto>>(categoryRepository);
            return Ok(mapcategoryrepository);
        }
    }
}
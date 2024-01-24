using API.Errors;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BrandsController : BaseApiController
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Brand> _brandRepo;

        public BrandsController(IMapper mapper, IGenericRepository<Brand> brandRepo)
        {
            _mapper = mapper;
            _brandRepo = brandRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Brand>>> GetBrands()
        {
            var brands = await _brandRepo.ListAllAsync();
            return Ok(brands);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Brand>> GetBrand(int id)
        {
            var brand = await _brandRepo.GetByIdAsync(id);
            if (brand == null) return NotFound(new ApiResponse(404));
            return Ok(brand);
        }
    }
}
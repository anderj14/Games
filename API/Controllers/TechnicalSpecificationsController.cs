
using API.Errors;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class TechnicalSpecificationsController : BaseApiController
    {
        private readonly IGenericRepository<TechnicalSpecification> _techRepo;

        public TechnicalSpecificationsController(IGenericRepository<TechnicalSpecification> techRepo)
        {
            _techRepo = techRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<TechnicalSpecification>>> GetTechnicalSpecifications()
        {
            var techSpecifications = await _techRepo.ListAllAsync();
            return Ok(techSpecifications);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IReadOnlyList<TechnicalSpecification>>> GetTechnicalSpecification(int id)
        {
            var techSpecification = await _techRepo.GetByIdAsync(id);
            if (techSpecification == null) return NotFound(new ApiResponse(404));
            return Ok(techSpecification);
        }
    }
}
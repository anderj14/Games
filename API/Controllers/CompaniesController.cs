using API.Errors;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class CompaniesController : BaseApiController
    {
        private readonly IGenericRepository<Company> _companyRepo;

        public CompaniesController(IGenericRepository<Company> companyRepo)
        {
            _companyRepo = companyRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Company>>> GetCompanies()
        {
            var companies = await _companyRepo.ListAllAsync();
            return Ok(companies);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Company>> GetCompany(int id)
        {
            var company = await _companyRepo.GetByIdAsync(id);
            if (company == null) return NotFound(new ApiResponse(404));
            return Ok(company);
        }
    }
}
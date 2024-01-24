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
        public async Task<ActionResult<Company>> GetCompany(int id)
        {
            var company = await _companyRepo.GetByIdAsync(id);
            return Ok(company);
        }
    }
}
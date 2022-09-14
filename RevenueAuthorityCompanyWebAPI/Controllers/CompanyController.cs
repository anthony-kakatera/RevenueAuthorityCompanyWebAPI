using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RevenueAuthorityCompanyWebAPI.Models;
using RevenueAuthorityCompanyWebAPI.Service;

namespace RevenueAuthorityCompanyWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<Company>> Get() { 
            var companies =  _companyService.GetAll();

            if(companies == null)
                return NotFound();

            return Ok(companies);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<Company>> Add([FromBody] Company _company) {
            var company = await _companyService.Add(_company);
            return CreatedAtAction("Get", new { id=company.Id}, company);
        }
    }
}

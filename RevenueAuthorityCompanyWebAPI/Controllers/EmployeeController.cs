using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RevenueAuthorityCompanyWebAPI.Models;
using RevenueAuthorityCompanyWebAPI.Service;

namespace RevenueAuthorityCompanyWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        //service
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet("companyid/{companyid}", Name = "GetEmployeesByCompany")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<Employee>> GetAllByCompanyId(int companyid) {
            var employees = _employeeService.GetAllByCompanyId(companyid);
            return Ok(employees);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Employee>> Add([FromBody] Employee employee) {
           return await _employeeService.Add(employee);
        }

        [HttpGet("{id}", Name = "GetEmployeeById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public Employee Get(int id) {
            return _employeeService.Get(id);
        }

        [HttpPost("bulk")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<Employee>>> AddAll([FromBody] List<Employee> employees) {
            var employeeList = await _employeeService.AddAll(employees);
            return Ok(employeeList);
        }
    }
}

using RevenueAuthorityCompanyWebAPI.Data;
using RevenueAuthorityCompanyWebAPI.Models;

namespace RevenueAuthorityCompanyWebAPI.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        //using json storage
        JSONStorage jsonStorage = new JSONStorage();

        //write employee to json file
        public Task<Employee> Add(Employee employee)
        {
            return jsonStorage.WriteJsonEmployeeAsync(employee);
        }

        public Task<List<Employee>> AddAll(List<Employee> employees)
        {
            return jsonStorage.WriteJsonEmployeesAsync(employees);
        }

        //get employee
        Employee IEmployeeRepository.Get(int id)
        {
            return jsonStorage.GetJsonEmployeeById(id);
        }

        //get all employees belonging to a specific company
        List<Employee> IEmployeeRepository.GetAllByCompanyId(int companyId)
        {
            return jsonStorage.GetJsonEmployeesByCompanyId(companyId);
        }
    }
}

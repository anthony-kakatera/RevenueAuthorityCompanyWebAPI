using RevenueAuthorityCompanyWebAPI.Models;

namespace RevenueAuthorityCompanyWebAPI.Service
{
    public interface IEmployeeService
    {
        List<Employee> GetAllByCompanyId(int companyId);
        Employee Get(int id);
        Task<Employee> Add(Employee employee);
        Task<List<Employee>> AddAll(List<Employee> employees);
    }
}

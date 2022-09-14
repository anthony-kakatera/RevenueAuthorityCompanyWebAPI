using RevenueAuthorityCompanyWebAPI.Models;

namespace RevenueAuthorityCompanyWebAPI.Repository
{
    public interface IEmployeeRepository
    {
        public List<Employee> GetAllByCompanyId(int companyId);
        public Employee Get(int id);
        Task<Employee> Add(Employee employee);
        Task<List<Employee>> AddAll(List<Employee> employees);
    }
}

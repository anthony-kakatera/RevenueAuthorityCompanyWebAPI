using RevenueAuthorityCompanyWebAPI.Models;

namespace RevenueAuthorityCompanyWebAPI.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public Task<Employee> Add(Employee employee)
        {
            return _unitOfWork.Emplyees.Add(employee);
        }

        public Task<List<Employee>> AddAll(List<Employee> employees)
        {
            return _unitOfWork.Emplyees.AddAll(employees);
        }

        public Employee Get(int id)
        {
            return _unitOfWork.Emplyees.Get(id);
        }

        public List<Employee> GetAllByCompanyId(int companyId)
        {
            return _unitOfWork.Emplyees.GetAllByCompanyId(companyId);
        }
    }
}

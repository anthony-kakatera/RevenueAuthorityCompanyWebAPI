using RevenueAuthorityCompanyWebAPI.Service;

namespace RevenueAuthorityCompanyWebAPI.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private EmployeeRepository employeeRepository;
        private CompanyRepository companyRepository;


        public IEmployeeRepository Emplyees =>
             employeeRepository = employeeRepository ?? new EmployeeRepository();

        public ICompanyRepository Companies => 
            companyRepository = companyRepository ?? new CompanyRepository();
    }
}

using RevenueAuthorityCompanyWebAPI.Repository;

namespace RevenueAuthorityCompanyWebAPI.Service
{
    public interface IUnitOfWork
    {
        IEmployeeRepository Emplyees { get; }
        ICompanyRepository Companies { get; }
    }
}

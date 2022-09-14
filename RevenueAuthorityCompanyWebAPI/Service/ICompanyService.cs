using RevenueAuthorityCompanyWebAPI.Models;

namespace RevenueAuthorityCompanyWebAPI.Service
{
    public interface ICompanyService
    {
        List<Company> GetAll();
        Task<Company> Add(Company company);
    }
}

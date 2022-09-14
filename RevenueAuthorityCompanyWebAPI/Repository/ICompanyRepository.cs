using RevenueAuthorityCompanyWebAPI.Models;

namespace RevenueAuthorityCompanyWebAPI.Repository
{
    public interface ICompanyRepository
    {
        public List<Company> GetAll();
        Task<Company> Add(Company company);
    }
}

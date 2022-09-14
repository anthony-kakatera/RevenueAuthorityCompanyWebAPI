using RevenueAuthorityCompanyWebAPI.Models;

namespace RevenueAuthorityCompanyWebAPI.Service
{
    public class CompanyService : ICompanyService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CompanyService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<Company> Add(Company company)
        {
            return _unitOfWork.Companies.Add(company);
        }

        public List<Company> GetAll()
        {
            return _unitOfWork.Companies.GetAll();
        }
    }
}

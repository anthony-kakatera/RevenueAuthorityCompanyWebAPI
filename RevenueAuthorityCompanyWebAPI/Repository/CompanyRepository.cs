using RevenueAuthorityCompanyWebAPI.Data;
using RevenueAuthorityCompanyWebAPI.Models;

namespace RevenueAuthorityCompanyWebAPI.Repository
{
    public class CompanyRepository : ICompanyRepository
    {
        //using json storage
        JSONStorage jsonStorage = new JSONStorage();

        //write to json file
        public Task<Company> Add(Company company)
        {
            return jsonStorage.WriteJsonCompanyAsync(company);
        }

        //get all from json file
        public List<Company> GetAll()
        {
            return jsonStorage.LoadJsonCompany();
        }
    }
}

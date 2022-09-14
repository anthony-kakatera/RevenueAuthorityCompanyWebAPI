using Newtonsoft.Json;
using RevenueAuthorityCompanyWebAPI.Models;
using System.Reflection;

namespace RevenueAuthorityCompanyWebAPI.Data
{
    public class JSONStorage
    {
        //company json file path
        private string @companyFilePath;
        //employee json file path
        private string @employeeFilePath;

        public JSONStorage() {
            //initializing in constractor
            @companyFilePath = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory + @"..\..\..\..\", "data\\company.json");
            //employee json file path
            @employeeFilePath = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory + @"..\..\..\..\", "data\\employee.json");
        }

        //get all companies
        public List<Company> LoadJsonCompany()
        {
            using (StreamReader r = new StreamReader(@companyFilePath))
            {
                string json = r.ReadToEnd();
                //Always remember to close Stream reader as this is process will hold onto the file
                r.Close();
                //Retrieving list
                List<Company> companyList = JsonConvert.DeserializeObject<List<Company>>(json);
                //return companies
                return companyList;
            }
        }

        //list of employees belonging to an individual company.
        public List<Employee> GetJsonEmployeesByCompanyId(int companyId)
        {
            using (StreamReader r = new StreamReader(@employeeFilePath))
            {
                //get entire list
                string jsonFile = r.ReadToEnd();
                //Always remember to close Stream reader as this is process will hold onto the file
                r.Close();
                //Retrieving list
                List<Employee> employeeList = JsonConvert.DeserializeObject<List<Employee>>(jsonFile);
                //filter by company id
                List<Employee> filteredEmployeeList = employeeList.Where(e => e.Company.Id == companyId).ToList();
                //return employee
                return filteredEmployeeList;
            }
        }

        //get employee by employeeId
        public Employee GetJsonEmployeeById(int employeeId) {
            using (StreamReader r = new StreamReader(@employeeFilePath))
            {
                //get entire list
                string jsonFile = r.ReadToEnd();
                //Always remember to close Stream reader as this is process will hold onto the file
                r.Close();
                //Retrieving list
                List<Employee> employeeList = JsonConvert.DeserializeObject<List<Employee>>(jsonFile);
                //search for employee by id
                Employee employee = employeeList.Find(x => x.Id == employeeId);
                //return employee
                return employee;
            }
        }

        //get company by Id
        public Company GetJsonCompanyById(int companyId)
        {
            using (StreamReader r = new StreamReader(@companyFilePath))
            {
                //get entire list
                string jsonFile = r.ReadToEnd();
                //Always remember to close Stream reader as this is process will hold onto the file
                r.Close();
                //Retrieving list
                List<Company> companyList = JsonConvert.DeserializeObject<List<Company>>(jsonFile);
                //search for employee by id
                Company company = companyList.Find(x => x.Id == companyId);
                //return employee
                return company;
            }
        }

        //add company to json
        public async Task<Company> WriteJsonCompanyAsync(Company company) {
            using (StreamReader r = new StreamReader(@companyFilePath))
            {
                //get entire list
                string jsonFile = r.ReadToEnd();
                List<Company> companyList =  JsonConvert.DeserializeObject<List<Company>>(jsonFile);
                //Load new object into list and re-write file
                companyList.Add(company);
                //Always remember to close Stream reader as this is process will hold onto the file
                r.Close();
                //serialize
                string json = JsonConvert.SerializeObject(companyList.ToArray());
                //write string to file
                System.IO.File.WriteAllText(@companyFilePath, json);
                //return
                return company;
            }
        }

        //add an employee to json
        public async Task<Employee> WriteJsonEmployeeAsync(Employee employee)
        {
            using (StreamReader r = new StreamReader(@employeeFilePath))
            {
                //get entire list
                string jsonFile = r.ReadToEnd();
                List<Employee> employeeList = JsonConvert.DeserializeObject<List<Employee>>(jsonFile);
                //Load new object into list and re-write file
                employeeList.Add(employee);
                //Always remember to close Stream reader as this is process will hold onto the file
                r.Close();
                //serialize
                string json = JsonConvert.SerializeObject(employeeList.ToArray());
                //write string to file
                System.IO.File.WriteAllText(@employeeFilePath, json);
                //return
                return employee;    
            }
        }

        //add an employee to json
        public async Task<List<Employee>> WriteJsonEmployeesAsync(List<Employee> employees)
        {
            using (StreamReader r = new StreamReader(@employeeFilePath))
            {
                //get entire list
                string jsonFile = r.ReadToEnd();
                List<Employee> employeeList = JsonConvert.DeserializeObject<List<Employee>>(jsonFile);
                //Load new object into list and re-write file
                employeeList.AddRange(employees);
                //Always remember to close Stream reader as this is process will hold onto the file
                r.Close();
                //serialize
                string json = JsonConvert.SerializeObject(employeeList.ToArray());
                //write string to file
                System.IO.File.WriteAllText(@employeeFilePath, json);
                //return
                return employees;
            }
        }

        //get all employees
        public List<Employee> LoadJsonEmployee()
        {
            using (StreamReader r = new StreamReader(employeeFilePath))
            {
                string json = r.ReadToEnd();
                //Always remember to close Stream reader as this is process will hold onto the file
                r.Close();
                //Retrieving list
                List<Employee> employeeList = JsonConvert.DeserializeObject<List<Employee>>(json);
                //return employees
                return employeeList;
            }
        }
    }

    
}

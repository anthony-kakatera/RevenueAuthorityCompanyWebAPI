using Microsoft.AspNetCore.Mvc;
using RevenueAuthorityCompanyWebAPI.Controllers;
using RevenueAuthorityCompanyWebAPI.Models;
using RevenueAuthorityCompanyWebAPI.Repository;
using RevenueAuthorityCompanyWebAPI.Service;

namespace UnitTest
{
    public class UnitTest
    {
        //Testing 
        [Fact]
        public void Test1()
        {
            //Arrange
            //getting the unitof work
            IUnitOfWork _unitOfWork = new UnitOfWork();
            //getting the service
            ICompanyService companyService = new CompanyService(_unitOfWork);
            //initializing the controller
            var companyController = new CompanyController(companyService);
            //Act
            var actionResult = companyController.Get();
            //Assert
            var result = actionResult.Result as OkObjectResult;
            var returnCompanies = result.Value as List<Company>;

            Assert.NotNull(returnCompanies);
        }

        [Fact]
        public async Task Test2()
        {
            //Arrange
            //getting the unitof work
            IUnitOfWork _unitOfWork = new UnitOfWork();
            //getting the service
            ICompanyService companyService = new CompanyService(_unitOfWork);
            //initializing the controller
            var companyController = new CompanyController(companyService);
            //company object
            Company newCompany = new Company();
            newCompany.Address = "Nowhere";
            newCompany.Email = "somewherefar@gmail.com";
            newCompany.Phone = "+26578373643";
            newCompany.Name = "Mizwaxer";
            //Act
            await companyController.Add(newCompany);

            var actionResult = companyController.Get();
            //Assert
            var result = actionResult.Result as OkObjectResult;
            var companyList = result.Value as List<Company>;


            //Assert
            foreach (var company in companyList)
            {
                if (Object.Equals(company, newCompany))
                {
                    Assert.Equal(newCompany, company);
                }
            }
        }

        [Fact]
        public void Test3()
        {
            //Arrange
            //getting the unitof work
            IUnitOfWork _unitOfWork = new UnitOfWork();
            //getting the service
            IEmployeeService employeeService = new EmployeeService(_unitOfWork);
            //loading controller
            var employeeController = new EmployeeController(employeeService);
            //Act
            var actionResult = employeeController.GetAllByCompanyId(0);
            //Assert
            var result = actionResult.Result as OkObjectResult;
            var returnEmployees = result.Value as List<Employee>;

            Assert.NotNull(returnEmployees);
        }

        [Fact]
        public void Test4()
        {
            //Arrange
            //getting the unitof work
            IUnitOfWork _unitOfWork = new UnitOfWork();
            //getting the service
            IEmployeeService employeeService = new EmployeeService(_unitOfWork);
            //loading controller
            var employeeController = new EmployeeController(employeeService);
            //Act
            var employee = employeeController.Get(1);
            //assert
            Assert.IsType<Employee>(employee);
        }

        [Fact]
        public void Test5()
        {
            //Arrange
            //getting the unitof work
            IUnitOfWork _unitOfWork = new UnitOfWork();
            //getting the service
            IEmployeeService employeeService = new EmployeeService(_unitOfWork);
            //loading controller
            var employeeController = new EmployeeController(employeeService);
            //company object
            Company newCompany = new Company();
            newCompany.Id = 3;
            newCompany.Address = "Lincoln Road";
            newCompany.Email = "bw@gmail.com";
            newCompany.Phone = "+2365854854";
            newCompany.Name = "Bowman & Wiser";
            //test employee
            Employee employee = new Employee();
            employee.Id = 6;
            employee.Name = "Jakeroly Mwinga";
            employee.email = "woodsRunner@gmail.com";
            employee.Company = newCompany;
            //Act
            _ = employeeController.Add(employee);
            //get all employees
            var newEmployee = employeeController.Get(6);
            //Assert
            Assert.True(employee.Id == newEmployee.Id && employee.Name == newEmployee.Name && employee.email == newEmployee.email);
        }
    }
}
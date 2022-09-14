using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RevenueAuthorityCompanyWebAPI.Controllers;
using RevenueAuthorityCompanyWebAPI.Models;
using RevenueAuthorityCompanyWebAPI.Repository;
using RevenueAuthorityCompanyWebAPI.Service;

namespace UnitTest
{
    public class UnitTest2
    {
        [Fact]
        public async void Test1()
        {
            //Arrange
            //getting the unitof work
            IUnitOfWork _unitOfWork = new UnitOfWork();
            //getting the service
            IEmployeeService employeeService = new EmployeeService(_unitOfWork);
            //loading controller
            var employeeController = new EmployeeController(employeeService);
            //creating objects
            //company object 1
            Company newCompany1 = new Company();
            newCompany1.Id = 3;
            newCompany1.Address = "Lincoln Road";
            newCompany1.Email = "bw@gmail.com";
            newCompany1.Phone = "+2365854854";
            newCompany1.Name = "Bowman & Wiser";
            //test employee 1
            Employee employee1 = new Employee();
            employee1.Id = 32;
            employee1.Name = "David Linch";
            employee1.email = "davidlynch@gmail.com";
            employee1.Company = newCompany1;

            //company object 2
            Company newCompany2 = new Company();
            newCompany2.Id = 3;
            newCompany2.Address = "Lincoln Road";
            newCompany2.Email = "bw@gmail.com";
            newCompany2.Phone = "+2365854854";
            newCompany2.Name = "Bowman & Wiser";
            //test employee 2
            Employee employee2 = new Employee();
            employee2.Id = 47;
            employee2.Name = "Spilberg Mwendo";
            employee2.email = "spillbergmwendo@gmail.com";
            employee2.Company = newCompany2;

            List<Employee> employees = new List<Employee>();
            employees.Add(employee2);
            employees.Add(employee1);

            var actionResult = await employeeController.AddAll(employees);
            //Assert
            var result =  actionResult.Result as OkObjectResult;
            var returnedEmployees = result.Value as List<Employee>;

            int count = 0;
            foreach (Employee returnedEmployee in returnedEmployees) {
                foreach (Employee newListEmployee in employees) {
                    if (Object.Equals(newListEmployee, returnedEmployee)) { count++; }
                }
            }

            if (count == returnedEmployees.Count) Assert.True(true);
        }
    }
}

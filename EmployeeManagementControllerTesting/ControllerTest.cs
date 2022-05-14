using EmployeeManagementBusinessLayer;
using EmployeeManagementEntity;
using EmployeeManagementPresentationLayer.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace EmployeeManagementControllerTesting
{
    public class ControllerTest
    {
        private readonly Mock<IEmployeeBAL> _mockEmployee;
        private readonly Mock<IValidateData> _mockValidate;

        private readonly EmployeeController _CBL;
        public ControllerTest()
        {
            _mockEmployee = new Mock<IEmployeeBAL>();
            _mockValidate = new Mock<IValidateData>();
            _CBL = new EmployeeController(_mockEmployee.Object, _mockValidate.Object);
        }

        [Fact]
        public void AddEmployee()
        {
            EmployeeDetailsEntity employee = new EmployeeDetailsEntity()
            {
                Id = "MT10145",
                _Name = "Samarth Goel",
                Gender = "Male",
                DOB = "26/04/1998",
                ContactNumber = "7535918304",
                Email = "Ssam2goel@gmail.com",
                Salary = (decimal)3.5
            };
            _mockEmployee.Setup(p => p.AddEmployee(employee)).ReturnsAsync(true);
            var result = _CBL.Save(employee);
            Xunit.Assert.IsType<CreatedResult>(result.Result);
        }

        [Fact]
        public void DeleteEmployee()
        {

            _mockEmployee.Setup(p => p.DeleteEmployee("MT10145")).ReturnsAsync(true);
            var result = _CBL.DeleteEmployee("MT10145");
            Xunit.Assert.IsType<NoContentResult>(result.Result);
        }

        [Fact]
        public void GetEmployee()
        {
            List<EmployeeDetailsEntity> employeeDetails = new List<EmployeeDetailsEntity>();
            _mockEmployee.Setup(p => p.GetEmployee()).ReturnsAsync(employeeDetails);
            var result = _CBL.Get();

            Assert.NotNull(result);

        }


    }
}

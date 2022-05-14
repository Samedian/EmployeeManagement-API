using EmployeeManagementBusinessLayer;
using EmployeeManagementDataAccessLayer;
using EmployeeManagementEntity;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EmployeeManagementControllerTesting
{
    public class BusinessLayerTest
    {
        private readonly Mock<IEmployeeDAL> _mockEmployee;
        private readonly Mock<IValidateData> _mockValidate;
        EmployeeBAL employeeBAL;

        public BusinessLayerTest()
        {
            _mockEmployee = new Mock<IEmployeeDAL>();
            _mockValidate = new Mock<IValidateData>();
            employeeBAL = new EmployeeBAL(_mockEmployee.Object, _mockValidate.Object);

        }
        [Fact]
        public async Task AddEmployee()
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
            _mockValidate.Setup(p => p.Validate(employee)).Returns(true);
            var result = await employeeBAL.AddEmployee(employee);
            Assert.Equal(true, result);
        }

        [Fact]
        public async Task DeleteEmployee()
        {
            var mockEmployee = new Mock<IEmployeeDAL>();
            var mockValidate = new Mock<IValidateData>();
            EmployeeDetailsEntity employee = new EmployeeDetailsEntity();

            EmployeeBAL balObject = new EmployeeBAL(mockEmployee.Object, mockValidate.Object);

            mockEmployee.Setup(p => p.DeleteEmployee("MT10145")).ReturnsAsync(true);
            mockValidate.Setup(p => p.Validate(employee)).Returns(true);

            var result = await balObject.DeleteEmployee("MT10145");
            Assert.Equal(true, result);

        }
        [Fact]
        public async Task GetEmployeeList()
        {

            var mockEmployee = new Mock<IEmployeeDAL>();
            var mockValidate = new Mock<IValidateData>();


            List<EmployeeDetailsEntity> employeeList = new List<EmployeeDetailsEntity>();
            EmployeeDetailsEntity employee = new EmployeeDetailsEntity();

            mockEmployee.Setup(p => p.GetEmployee()).ReturnsAsync(employeeList);
            mockValidate.Setup(p => p.Validate(employee)).Returns(true);
            EmployeeBAL balObject = new EmployeeBAL(mockEmployee.Object, mockValidate.Object);
            List<EmployeeDetailsEntity> result = await balObject.GetEmployee();
            Assert.Equal(employeeList.Count, result.Count);
        }

        //[Fact]
        //public async Task Validate()
        //{

        //    EmployeeDetailsEntity employee = new EmployeeDetailsEntity()
        //    {
        //        Id = "MT10145",
        //        _Name = "Samarth Goel",
        //        Gender = "Male",
        //        DOB = "26/04/1998",
        //        ContactNumber = "7535918304",
        //        Email = "Ssam2goel@gmail.com",
        //        Salary = (decimal)3.5

        //    };
        //    ValidateData validate = new ValidateData();
           
        //    var result = validate.Validate(employee);
        //    Assert.Equal(true, result);
        //}

    }
}

using EmployeeManagementDataAccessLayer;
using EmployeeManagementEntity;
using EmployeeManagementException;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagementBusinessLayer
{
    public class EmployeeBAL : IEmployeeBAL
    {
        private readonly IEmployeeDAL _employeeDAL;
        private readonly IValidateData _validateData;
        public EmployeeBAL(IEmployeeDAL employeeDAL, IValidateData validateData)
        {
            _employeeDAL = employeeDAL;
            _validateData = validateData;
        }

        /// <summary>
        /// Validate & Send Employee details to DAL Layer and response accordingly
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public async Task<bool> AddEmployee(EmployeeDetailsEntity employee)
        {
            bool result = false;

            if (!_validateData.Validate(employee))
                throw new BadRequest("Invalid Input");
            result = await _employeeDAL.AddEmployee(employee);

            return result;

        }

        /// <summary>
        /// Send EmployeeId to DAL Layer
        /// </summary>
        /// <param name="employeetId"></param>
        /// <returns></returns>
        public async Task<bool> DeleteEmployee(string employeetId)
        {
            bool result;
            result = await _employeeDAL.DeleteEmployee(employeetId);
            return result;

        }

        /// <summary>
        /// Give Employee Deatils to Controller
        /// </summary>
        /// <returns></returns>
        public async Task<List<EmployeeDetailsEntity>> GetEmployee()
        {
            List<EmployeeDetailsEntity> employeeDetailsEntities =await _employeeDAL.GetEmployee();
            return employeeDetailsEntities;
        }
    }
}

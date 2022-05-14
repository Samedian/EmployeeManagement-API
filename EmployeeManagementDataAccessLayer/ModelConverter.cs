using EmployeeManagementDataAccessLayer.Model;
using EmployeeManagementEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagementDataAccessLayer
{
    public class ModelConverter : IModelConverter
    {
        /// <summary>
        /// Convert Entity to Model Object
        /// </summary>
        /// <param name="employeeDetailsEntity"></param>
        /// <returns></returns>

        public EmployeeDetail ConvertEntityToModel(EmployeeDetailsEntity employeeDetailsEntity)
        {
            EmployeeDetail employeeDetail = new EmployeeDetail();
            employeeDetail.Id = employeeDetailsEntity.Id;
            employeeDetail.Name = employeeDetailsEntity._Name;
            employeeDetail.Gender = employeeDetailsEntity.Gender;
            employeeDetail.Dob = Convert.ToDateTime(employeeDetailsEntity.DOB);
            employeeDetail.ContactNumber = employeeDetailsEntity.ContactNumber;
            employeeDetail.Email = employeeDetailsEntity.Email;
            employeeDetail.Salary = employeeDetailsEntity.Salary;

            return employeeDetail;
        }

        /// <summary>
        /// Convert Model to Entity Object
        /// </summary>
        /// <param name="employeeDetail"></param>
        /// <returns></returns>
        public EmployeeDetailsEntity ConvertModelToEntity(EmployeeDetail employeeDetail)
        {
            EmployeeDetailsEntity employeeDetailsEntity = new EmployeeDetailsEntity();
            employeeDetailsEntity.Id = employeeDetail.Id;
            employeeDetailsEntity._Name = employeeDetail.Name;
            employeeDetailsEntity.Gender = employeeDetail.Gender;
            employeeDetailsEntity.DOB = employeeDetail.Dob.ToString();
            employeeDetailsEntity.ContactNumber = employeeDetail.ContactNumber;
            employeeDetailsEntity.Email = employeeDetail.Email;
            employeeDetailsEntity.Salary = (decimal)employeeDetail.Salary;

            return employeeDetailsEntity;
        }
    }
}

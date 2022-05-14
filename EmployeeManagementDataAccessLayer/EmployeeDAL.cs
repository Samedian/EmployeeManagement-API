using EmployeeManagementDataAccessLayer.Model;
using EmployeeManagementEntity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementDataAccessLayer
{
    public class EmployeeDAL : IEmployeeDAL
    {
        private readonly EmployeemanagementContext _context;
        private readonly IModelConverter _modelConverter;
        public EmployeeDAL(EmployeemanagementContext employeemanagementContext,IModelConverter modelConverter)
        {
            _context = employeemanagementContext;
            _modelConverter = modelConverter;
        }

        /// <summary>
        /// Add Employee details to DB
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public async Task<bool> AddEmployee(EmployeeDetailsEntity employee)
        {
            EmployeeDetail employeeDetail = _modelConverter.ConvertEntityToModel(employee);
            try
            {
                await _context.EmployeeDetails.AddAsync(employeeDetail);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Delete Employee from Db by ID
        /// </summary>
        /// <param name="employeetId"></param>
        /// <returns></returns>
        public async Task<bool> DeleteEmployee(string employeetId)
        {
            try
            {
                var employee = _context.EmployeeDetails.FirstOrDefault(x => x.Id == employeetId);
                _context.EmployeeDetails.Remove(employee);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                return false;
            }

            return true;

        }

        /// <summary>
        /// fetch Employee List 
        /// </summary>
        /// <returns></returns>
        public async Task<List<EmployeeDetailsEntity>> GetEmployee()
        {
            List<EmployeeDetail> employeeDetails = null;
            try
            {
                employeeDetails = _context.EmployeeDetails.ToList();
                await _context.SaveChangesAsync();
            }catch(Exception ex)
            {
                return null;
            }

            List<EmployeeDetailsEntity> employeeDetailsEntities = new List<EmployeeDetailsEntity>();
            foreach (var data in employeeDetails)
            {
                EmployeeDetailsEntity employeeDetailsEntity = _modelConverter.ConvertModelToEntity(data);
                employeeDetailsEntities.Add(employeeDetailsEntity);
            }
            return employeeDetailsEntities;
        }
    }
}

using EmployeeManagementEntity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagementBusinessLayer
{
    public interface IEmployeeBAL
    {
        Task<bool> AddEmployee(EmployeeDetailsEntity Employee);
        Task<bool> DeleteEmployee(string EmployeetId);
        Task<List<EmployeeDetailsEntity>> GetEmployee();
    }
}
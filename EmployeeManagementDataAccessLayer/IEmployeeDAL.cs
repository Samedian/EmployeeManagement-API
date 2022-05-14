using EmployeeManagementEntity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagementDataAccessLayer
{
    public interface IEmployeeDAL
    {
        Task<bool> AddEmployee(EmployeeDetailsEntity Employee);
        Task<bool> DeleteEmployee(string EmployeetId);
        Task<List<EmployeeDetailsEntity>> GetEmployee();
    }
}
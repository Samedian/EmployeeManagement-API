using EmployeeManagementEntity;

namespace EmployeeManagementBusinessLayer
{
    public interface IValidateData
    {
        bool Validate(EmployeeDetailsEntity employeedetail);
    }
}
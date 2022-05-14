using EmployeeManagementDataAccessLayer.Model;
using EmployeeManagementEntity;

namespace EmployeeManagementDataAccessLayer
{
    public interface IModelConverter
    {
        EmployeeDetail ConvertEntityToModel(EmployeeDetailsEntity employeeDetailsEntity);
        EmployeeDetailsEntity ConvertModelToEntity(EmployeeDetail employeeDetail);
    }
}
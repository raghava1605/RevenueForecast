using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevenueForecast.Common.Models.Interfaces
{
    public interface IEmployeeRoles
    {
        IEnumerable<EmployeeRolesModel> GetEmployeeRoles();
        EmployeeRolesModel GetEmployeeRolesById(int employeeRoleID);
        string SaveEmployeesRolesDetails(EmployeeRolesModel employeeRoleModel);
        string DeleteEmployeesRoles(int employeeRoleID);
    }
}

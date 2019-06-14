using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevenueForecast.Common.Models.Interfaces
{
    public interface IEmployee
    {
        IEnumerable<EmployeeModel> GetEmployees();
        EmployeeModel GetEmployeeById(int employeeID);
        string SaveEmployeesDetails(EmployeeModel employeeModel);
        string DeleteEmployees(int employeeID);
    }
}

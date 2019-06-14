using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevenueForecast.Common.Models
{
    public class EmployeeModel
    {
        public int EmployeeID { get; set; }
        public string EmpName { get; set; }
        public bool IsActive { get; set; }
        public int RoleID { get; set; }
        public int LocationID { get; set; }

        //Additional Properties 
        public string RoleName { get; set; }
        public string RoleDescription { get; set; }
        public string LocationName { get; set; }
    }
}

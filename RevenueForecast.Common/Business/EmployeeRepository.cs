using AutoMapper;
using RevenueForecast.Common.Data;
using RevenueForecast.Common.Models;
using RevenueForecast.Common.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevenueForecast.Common.Business
{
    public class EmployeeRepository : IEmployee
    {
        #region Variables
        private OperationalPortalDBEntities _OperationalPortalEntities;
        //  private static Logger logger = LogManager.GetCurrentClassLogger();
        #endregion

        #region Constructors
        public EmployeeRepository(OperationalPortalDBEntities OperationalPortalEntities)
        {
            // logger.Info("OperationalPortalEntities Instance is going to create");
            _OperationalPortalEntities = OperationalPortalEntities;
            //  logger.Info("OperationalPortalEntities Instance is created successfully");
        }
        #endregion

        #region Members
        /// <summary>
        /// Get Customers List 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<EmployeeModel> GetEmployees()
        {
            //logger.Info("Start Fetch Customer");
            List<EmployeeModel> employeeList = (from emp in _OperationalPortalEntities.Employees
                                                join er in _OperationalPortalEntities.EmployeeRoles on emp.RoleID equals er.RoleID
                                                join lc in _OperationalPortalEntities.Locations on emp.RoleID equals lc.LocationID
                                                select new EmployeeModel()
                                                {
                                                    EmpName = emp.EmpName,
                                                    EmployeeID = emp.EmployeeID,
                                                    IsActive = emp.IsActive,
                                                    RoleID = er.RoleID,
                                                    RoleName = er.RoleName,
                                                    RoleDescription = er.RoleDecription,
                                                    LocationID = lc.LocationID,
                                                    LocationName = lc.LocationName
                                                }).ToList();                                        
            //List<Employee> employees = _OperationalPortalEntities.Employees.ToList();
           // List<EmployeeModel> employeeList = Mapper.Map<List<Employee>, List<EmployeeModel>>(employees);
            return employeeList;
        }

        public EmployeeModel GetEmployeeById(int employeeID)
        {
            var employee = _OperationalPortalEntities.Employees.FirstOrDefault(x => x.EmployeeID == employeeID);
            EmployeeModel employeeObj = Mapper.Map<Employee, EmployeeModel>(employee);
            return employeeObj;
        }

        public string SaveEmployeesDetails(EmployeeModel employeeModel)
        {
            string result = string.Empty;
            try
            {

                Employee employee = _OperationalPortalEntities.Employees.FirstOrDefault(x => x.EmployeeID == employeeModel.EmployeeID);
                if (employee != null)
                {
                    Mapper.Map(employeeModel, employee);
                    result = "Employee Updated Successfully";
                }
                else
                {
                    employee = new Employee();
                    Mapper.Map(employeeModel, employee);
                    _OperationalPortalEntities.Employees.Add(employee);
                    result = "Employee Saved Successfully";
                }
                _OperationalPortalEntities.SaveChanges();
            }
            catch (Exception ex)
            {
                result = ex.Message.ToString();
            }
            return result;

        }

        public string DeleteEmployees(int employeeID)
        {
            string result = string.Empty;
            try
            {
                Employee employee = _OperationalPortalEntities.Employees.FirstOrDefault(x => x.EmployeeID == employeeID);
                if (employee != null)
                {
                    _OperationalPortalEntities.Employees.Remove(employee);
                    _OperationalPortalEntities.SaveChanges();
                    result = "Employee Removed Successfully";
                }
                else
                {
                    result = "Employee Does not exist";
                }
            }
            catch (Exception ex)
            {
                result = ex.Message.ToString();
            }
            return result;
        }


        #endregion
    }
}

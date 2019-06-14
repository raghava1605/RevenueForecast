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
    public class EmployeeRolesRepository : IEmployeeRoles
    {
        #region Variables
        private OperationalPortalDBEntities _OperationalPortalEntities;
        //  private static Logger logger = LogManager.GetCurrentClassLogger();
        #endregion

        #region Constructors
        public EmployeeRolesRepository(OperationalPortalDBEntities OperationalPortalEntities)
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
        public IEnumerable<EmployeeRolesModel> GetEmployeeRoles()
        {
            //logger.Info("Start Fetch Customer");
            List<EmployeeRole> employeeRole = _OperationalPortalEntities.EmployeeRoles.ToList();
            List<EmployeeRolesModel> employeeRoleList = Mapper.Map<List<EmployeeRole>, List<EmployeeRolesModel>>(employeeRole);
            return employeeRoleList;
        }

        public EmployeeRolesModel GetEmployeeRolesById(int employeeRoleID)
        {
            var employeeRole = _OperationalPortalEntities.EmployeeRoles.FirstOrDefault(x => x.RoleID == employeeRoleID);
            EmployeeRolesModel employeeRoleObj = Mapper.Map<EmployeeRole, EmployeeRolesModel>(employeeRole);
            return employeeRoleObj;
        }

        public string SaveEmployeesRolesDetails(EmployeeRolesModel employeeRolesModel)
        {
            string result = string.Empty;
            try
            {

                EmployeeRole employeeRole = _OperationalPortalEntities.EmployeeRoles.FirstOrDefault(x => x.RoleID == employeeRolesModel.RoleID);
                if (employeeRole != null)
                {
                    Mapper.Map(employeeRolesModel, employeeRole);
                    result = "EmployeeRole Updated Successfully";
                }
                else
                {
                    employeeRole = new EmployeeRole();
                    Mapper.Map(employeeRolesModel, employeeRole);
                    _OperationalPortalEntities.EmployeeRoles.Add(employeeRole);
                    result = "EmployeeRole Saved Successfully";
                }
                _OperationalPortalEntities.SaveChanges();
            }
            catch (Exception ex)
            {
                result = ex.Message.ToString();
            }
            return result;

        }

        public string DeleteEmployeesRoles(int employeeRoleID)
        {
            string result = string.Empty;
            try
            {
                EmployeeRole employeeRole = _OperationalPortalEntities.EmployeeRoles.FirstOrDefault(x => x.RoleID == employeeRoleID);
                if (employeeRole != null)
                {
                    _OperationalPortalEntities.EmployeeRoles.Remove(employeeRole);
                    _OperationalPortalEntities.SaveChanges();
                    result = "EmployeeRole Removed Successfully";
                }
                else
                {
                    result = "EmployeeRole Does not exist";
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

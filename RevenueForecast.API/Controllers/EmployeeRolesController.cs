using NLog;
using RevenueForecast.Common.Models;
using RevenueForecast.Common.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace RevenueForecast.API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class EmployeeRolesController : ApiController
    {
        #region Variables
        IEmployeeRoles _employeeRolesInfo;
        private static Logger logger = LogManager.GetCurrentClassLogger();
        #endregion

        #region Constructors
        public EmployeeRolesController(IEmployeeRoles employeeRolesInfo)
        {
            _employeeRolesInfo = employeeRolesInfo;
        }
        #endregion

        #region Members

        [HttpGet]
        public IHttpActionResult Get()
        {
            logger.Info("Get Employee Roles");
            var employeeRoles = _employeeRolesInfo.GetEmployeeRoles();
            if (employeeRoles == null)
            {
                return NotFound();
            }
            return Ok(employeeRoles);
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var employeeRoles = _employeeRolesInfo.GetEmployeeRolesById(id);
            if (employeeRoles == null)
            {
                return NotFound();
            }
            return Ok(employeeRoles);
        }

        [HttpPost]
        public IHttpActionResult SaveEmployeeRoles([FromBody]EmployeeRolesModel employeeRolesModel)
        {
            var employeeRoles = _employeeRolesInfo.SaveEmployeesRolesDetails(employeeRolesModel);
            if (employeeRoles == null)
            {
                return NotFound();
            }
            return Ok(employeeRoles);
        }

        [HttpDelete]
        public IHttpActionResult RemoveEmployeeRoles(int id)
        {
            var employeeRoles = _employeeRolesInfo.DeleteEmployeesRoles(id);
            if (employeeRoles == null)
            {
                return NotFound();
            }
            return Ok(employeeRoles);
        }
        #endregion
    }
}

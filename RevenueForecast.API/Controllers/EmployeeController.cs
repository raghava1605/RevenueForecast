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
    public class EmployeeController : ApiController
    {
        #region Variables
        IEmployee _employeeInfo;
        private static Logger logger = LogManager.GetCurrentClassLogger();
        #endregion

        #region Constructors
        public EmployeeController(IEmployee employeeInfo)
        {
            _employeeInfo = employeeInfo;
        }
        #endregion

        #region Members

        [HttpGet]
        public IHttpActionResult Get()
        {
            logger.Info("Get Customers");
            var employees = _employeeInfo.GetEmployees();
            if (employees == null)
            {
                return NotFound();
            }
            return Ok(employees);
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var employees = _employeeInfo.GetEmployeeById(id);
            if (employees == null)
            {
                return NotFound();
            }
            return Ok(employees);
        }

        [HttpPost]
        public IHttpActionResult SaveEmployee([FromBody]EmployeeModel employeeModel)
        {
            var employees = _employeeInfo.SaveEmployeesDetails(employeeModel);
            if (employees == null)
            {
                return NotFound();
            }
            return Ok(employees);
        }

        [HttpDelete]
        public IHttpActionResult RemoveEmployee(int id)
        {
            var employees = _employeeInfo.DeleteEmployees(id);
            if (employees == null)
            {
                return NotFound();
            }
            return Ok(employees);
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RevenueForecast.Common.Business;
using RevenueForecast.Common.Models.Interfaces;
using RevenueForecast.Common.Data;
using RevenueForecast.Common.Models;
using System.Web.Http.Cors;

namespace RevenueForecast.API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class CustomerController : ApiController
    {
        #region Variables
        ICustomer _customerInfo;
        #endregion

        #region Constructors
        public CustomerController(ICustomer customerInfo)
        {
            _customerInfo = customerInfo;
        }
        #endregion

        #region Members

        [HttpGet]
        public IHttpActionResult Get()
        {
            var customers = _customerInfo.GetCustomers();
            if (customers == null)
            {
                return NotFound();
            }
            return Ok(customers);
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var customers = _customerInfo.GetCustomerById(id);
            if (customers == null)
            {
                return NotFound();
            }
            return Ok(customers);
        }

        [HttpPost]
        public IHttpActionResult SaveCustomer([FromBody]CustomerModel customerModel)
        {
            var customers = _customerInfo.SaveCustomerDetails(customerModel);
            if (customers == null)
            {
                return NotFound();
            }
            return Ok(customers);
        }

        [HttpDelete]
        public IHttpActionResult RemoveCustomer(int customerId)
        {
            var customers = _customerInfo.DeleteCustomer(customerId);
            if (customers == null)
            {
                return NotFound();
            }
            return Ok(customers);
        }
        #endregion
    }
}

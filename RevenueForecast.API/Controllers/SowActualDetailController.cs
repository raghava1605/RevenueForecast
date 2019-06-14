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
    public class SowActualDetailController : ApiController
    {
        #region Variables
        ISowActualDetail _sowActualInfo;
        private static Logger logger = LogManager.GetCurrentClassLogger();
        #endregion

        #region Constructors
        public SowActualDetailController(ISowActualDetail sowActualInfo)
        {
            _sowActualInfo = sowActualInfo;
        }
        #endregion

        #region Members

        [HttpGet]
        public IHttpActionResult Get()
        {
            logger.Info("Get SowActual Details");
            var customers = _sowActualInfo.GetActualSows();
            if (customers == null)
            {
                return NotFound();
            }
            return Ok(customers);
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var customers = _sowActualInfo.GetActualSowDetailById(id);
            if (customers == null)
            {
                return NotFound();
            }
            return Ok(customers);
        }

        [HttpPost]
        public IHttpActionResult SaveSowAcutalDetails([FromBody]SowDetailActualModel sowActualModel)
        {
            var customers = _sowActualInfo.SaveActualSowDetails(sowActualModel);
            if (customers == null)
            {
                return NotFound();
            }
            return Ok(customers);
        }

        [HttpDelete]
        public IHttpActionResult RemoveSowAcutalDetails(int sowActualID)
        {
            var customers = _sowActualInfo.DeleteActualSowDetail(sowActualID);
            if (customers == null)
            {
                return NotFound();
            }
            return Ok(customers);
        }
        #endregion
    }
}

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
    public class SowHeaderController : ApiController
    {
        #region Variables
        ISowHeader _sowheaderInfo;
        #endregion

        #region Constructors
        public SowHeaderController(ISowHeader sowheaderInfo)
        {
            _sowheaderInfo = sowheaderInfo;
        }
        #endregion

        #region Members

        [HttpGet]
        public IHttpActionResult Get()
        {
            var sowheader = _sowheaderInfo.GetSowHeaders();
            if (sowheader == null)
            {
                return NotFound();
            }
            return Ok(sowheader);
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var sowheader = _sowheaderInfo.GetSowHeaderById(id);
            if (sowheader == null)
            {
                return NotFound();
            }
            return Ok(sowheader);
        }

        [HttpPost]
        public IHttpActionResult SaveSowHeader([FromBody]SowHeaderModel sowHeaderModel)
        {
            var sowheader = _sowheaderInfo.SaveSowHeaderDetails(sowHeaderModel);
            if (sowheader == null)
            {
                return NotFound();
            }
            return Ok(sowheader);
        }

        [HttpDelete]
        public IHttpActionResult RemoveSowHeader(int id)
        {
            var sowheader = _sowheaderInfo.DeleteSowHeader(id);
            if (sowheader == null)
            {
                return NotFound();
            }
            return Ok(sowheader);
        }
        #endregion
    }
}

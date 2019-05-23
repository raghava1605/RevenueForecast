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
    public class SowPlannedController : ApiController
    {
        #region Variables
        ISowPlanned _sowplannedInfo;
        #endregion

        #region Constructors
        public SowPlannedController(ISowPlanned sowplannedInfo)
        {
            _sowplannedInfo = sowplannedInfo;
        }
        #endregion

        #region Members

        [HttpGet]
        public IHttpActionResult Get()
        {
            var sowheader = _sowplannedInfo.GetSowPlannedDetails();
            if (sowheader == null)
            {
                return NotFound();
            }
            return Ok(sowheader);
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var sowdetails = _sowplannedInfo.GetSowPlannedDetailsById(id);
            if (sowdetails == null)
            {
                return NotFound();
            }
            return Ok(sowdetails);
        }

        [HttpPost]
        public IHttpActionResult SaveSowHeader([FromBody]SowPlannedModel sowPlannedModel)
        {
            var sowdetails = _sowplannedInfo.SaveSowPlannedDetails(sowPlannedModel);
            if (sowdetails == null)
            {
                return NotFound();
            }
            return Ok(sowdetails);
        }

        [HttpDelete]
        public IHttpActionResult RemoveSowHeader(int id)
        {
            var sowdetails = _sowplannedInfo.DeleteSowPlannedDetail(id);
            if (sowdetails == null)
            {
                return NotFound();
            }
            return Ok(sowdetails);
        }
        #endregion
    }
}

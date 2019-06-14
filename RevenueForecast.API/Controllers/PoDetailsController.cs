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
    public class PoDetailsController : ApiController
    {
        #region Variables
        IPoDetails _podetailsInfo;
        #endregion

        #region Constructors
        public PoDetailsController(IPoDetails podetailsInfo)
        {
            _podetailsInfo = podetailsInfo;
        }
        #endregion

        #region Members

        [HttpGet]
        public IHttpActionResult Get()
        {
            var podetail = _podetailsInfo.GetPoDetails();
            if (podetail == null)
            {
                return NotFound();
            }
            return Ok(podetail);
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var podetail = _podetailsInfo.GetPoDetailsById(id);
            if (podetail == null)
            {
                return NotFound();
            }
            return Ok(podetail);
        }

        [HttpPost]
        public IHttpActionResult SavePoDetail([FromBody]PoDetailsModel poDetailModel)
        {
            var podetail = _podetailsInfo.SavePoDetails(poDetailModel);
            if (podetail == null)
            {
                return NotFound();
            }
            return Ok(podetail);
        }

        [HttpDelete]
        public IHttpActionResult RemovePoDetail(int id)
        {
            var podetail = _podetailsInfo.DeletePoDetails(id);
            if (podetail == null)
            {
                return NotFound();
            }
            return Ok(podetail);
        }

        #endregion
    }
}

using RevenueForecast.Common.Models;
using RevenueForecast.Common.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RevenueForecast.API.Controllers
{
    public class PoHeaderController : ApiController
    {
        #region Variables
        IPoHeader _poheaderInfo;
        #endregion

        #region Constructors
        public PoHeaderController(IPoHeader poheaderInfo)
        {
            _poheaderInfo = poheaderInfo;
        }
        #endregion

        #region Members

        [HttpGet]
        public IHttpActionResult Get()
        {
            var poheader = _poheaderInfo.GetPoHeaders();
            if (poheader == null)
            {
                return NotFound();
            }
            return Ok(poheader);
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var poheader = _poheaderInfo.GetPoHeadersById(id);
            if (poheader == null)
            {
                return NotFound();
            }
            return Ok(poheader);
        }

        [HttpPost]
        public IHttpActionResult SavePoHeader([FromBody]PoHeaderModel poHeaderModel)
        {
            var poheader = _poheaderInfo.SavePoHeadersDetails(poHeaderModel);
            if (poheader == null)
            {
                return NotFound();
            }
            return Ok(poheader);
        }

        [HttpDelete]
        public IHttpActionResult RemovePoHeader(int id)
        {
            var poheader = _poheaderInfo.DeletePoHeaders(id);
            if (poheader == null)
            {
                return NotFound();
            }
            return Ok(poheader);
        }
        #endregion
    }

    
}

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
    public class MSAController : ApiController
    {
        #region Variables
        IMSA _msaInfo;
        #endregion

        #region Constructors
        public MSAController(IMSA msaInfo)
        {
            _msaInfo = msaInfo;
        }
        #endregion

        #region Members

        [HttpGet]
        public IHttpActionResult Get()

        {
            var msa = _msaInfo.GetMSA();
            if (msa == null)
            {
                return NotFound();
            }
            return Ok(msa);
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var msa = _msaInfo.GetMSAById(id);
            if (msa == null)
            {
                return NotFound();
            }
            return Ok(msa);
        }

        [HttpPost]
        public IHttpActionResult SaveMSA([FromBody]MSAModel msaModel)
        {
            var msa = _msaInfo.SaveMSADetails(msaModel);
            if (msa == null)
            {
                return NotFound();
            }
            return Ok(msa);
        }

        [HttpDelete]
        public IHttpActionResult RemoveMSA(int id)
        {
            var msa = _msaInfo.DeleteMSA(id);
            if (msa == null)
            {
                return NotFound();
            }
            return Ok(msa);
        }
        #endregion
    }
}

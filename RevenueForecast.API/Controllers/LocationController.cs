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
    public class LocationController : ApiController
    {
        #region Variables
        ILocation _locationInfo;
        private static Logger logger = LogManager.GetCurrentClassLogger();
        #endregion

        #region Constructors
        public LocationController(ILocation locationInfo)
        {
            _locationInfo = locationInfo;
        }
        #endregion

        #region Members

        [HttpGet]
        public IHttpActionResult Get()
        {
            logger.Info("Get Locations");
            var locations = _locationInfo.GetLocations();
            if (locations == null)
            {
                return NotFound();
            }
            return Ok(locations);
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var locations = _locationInfo.GetLocationsById(id);
            if (locations == null)
            {
                return NotFound();
            }
            return Ok(locations);
        }

        [HttpPost]
        public IHttpActionResult SaveLocation([FromBody]LocationModel locationModel)
        {
            var locations = _locationInfo.SaveLocationsDetails(locationModel);
            if (locations == null)
            {
                return NotFound();
            }
            return Ok(locations);
        }

        [HttpDelete]
        public IHttpActionResult RemoveLocation(int id)
        {
            var locations = _locationInfo.DeleteLocations(id);
            if (locations == null)
            {
                return NotFound();
            }
            return Ok(locations);
        }
        #endregion
    }
}

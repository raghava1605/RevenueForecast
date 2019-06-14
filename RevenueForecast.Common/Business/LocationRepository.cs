using AutoMapper;
using RevenueForecast.Common.Data;
using RevenueForecast.Common.Models;
using RevenueForecast.Common.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevenueForecast.Common.Business
{
    public class LocationRepository : ILocation
    {
        #region Variables
        private OperationalPortalDBEntities _OperationalPortalEntities;
        //  private static Logger logger = LogManager.GetCurrentClassLogger();
        #endregion

        #region Constructors
        public LocationRepository(OperationalPortalDBEntities OperationalPortalEntities)
        {
            // logger.Info("OperationalPortalEntities Instance is going to create");
            _OperationalPortalEntities = OperationalPortalEntities;
            //  logger.Info("OperationalPortalEntities Instance is created successfully");
        }
        #endregion

        #region Members
        /// <summary>
        /// Get Customers List 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<LocationModel> GetLocations()
        {
            //logger.Info("Start Fetch Customer");
            List<Location> locations = _OperationalPortalEntities.Locations.ToList();
            List<LocationModel> locationsList = Mapper.Map<List<Location>, List<LocationModel>>(locations);
            return locationsList;
        }

        public LocationModel GetLocationsById(int locationID)
        {
            var locations = _OperationalPortalEntities.Locations.FirstOrDefault(x => x.LocationID == locationID);
            LocationModel locationsObj = Mapper.Map<Location, LocationModel>(locations);
            return locationsObj;
        }

        public string SaveLocationsDetails(LocationModel locationModel)
        {
            string result = string.Empty;
            try
            {

                Location location = _OperationalPortalEntities.Locations.FirstOrDefault(x => x.LocationID == locationModel.LocationID);
                if (location != null)
                {
                    Mapper.Map(locationModel, location);
                    result = "Location Updated Successfully";
                }
                else
                {
                    location = new Location();
                    Mapper.Map(locationModel, location);
                    _OperationalPortalEntities.Locations.Add(location);
                    result = "Location Saved Successfully";
                }
                _OperationalPortalEntities.SaveChanges();
            }
            catch (Exception ex)
            {
                result = ex.Message.ToString();
            }
            return result;

        }

        public string DeleteLocations(int locationID)
        {
            string result = string.Empty;
            try
            {
                Location location = _OperationalPortalEntities.Locations.FirstOrDefault(x => x.LocationID == locationID);
                if (location != null)
                {
                    _OperationalPortalEntities.Locations.Remove(location);
                    _OperationalPortalEntities.SaveChanges();
                    result = "Location Removed Successfully";
                }
                else
                {
                    result = "Location Does not exist";
                }
            }
            catch (Exception ex)
            {
                result = ex.Message.ToString();
            }
            return result;
        }


        #endregion
    }
}

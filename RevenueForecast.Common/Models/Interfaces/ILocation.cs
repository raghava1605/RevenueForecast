using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevenueForecast.Common.Models.Interfaces
{
    public interface ILocation
    {
        IEnumerable<LocationModel> GetLocations();
        LocationModel GetLocationsById(int locationID);
        string SaveLocationsDetails(LocationModel locationModel);
        string DeleteLocations(int locationID);
    }
}

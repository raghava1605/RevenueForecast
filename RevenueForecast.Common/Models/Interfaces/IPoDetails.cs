using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevenueForecast.Common.Models.Interfaces
{
    public interface IPoDetails
    {
        IEnumerable<PoDetailsModel> GetPoDetails();
        PoDetailsModel GetPoDetailsById(int podId);
        string SavePoDetails(PoDetailsModel poDetailsModel);
        string DeletePoDetail(int podId);
    }
}

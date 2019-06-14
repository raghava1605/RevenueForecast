using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevenueForecast.Common.Models.Interfaces
{
    public interface ISowPlanned
    {
        IEnumerable<SowDetailModel> GetSowPlannedDetails();
        SowDetailModel GetSowPlannedDetailsById(int sowId);
        string SaveSowPlannedDetails(SowDetailModel sowPlannedModel);
        string DeleteSowPlannedDetail(int sowId);
    }
}

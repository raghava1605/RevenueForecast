using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevenueForecast.Common.Models.Interfaces
{
    public interface ISowPlanned
    {
        IEnumerable<SowPlannedModel> GetSowPlannedDetails();
        SowPlannedModel GetSowPlannedDetailsById(int sowId);
        string SaveSowPlannedDetails(SowPlannedModel sowPlannedModel);
        string DeleteSowPlannedDetail(int sowId);
    }
}

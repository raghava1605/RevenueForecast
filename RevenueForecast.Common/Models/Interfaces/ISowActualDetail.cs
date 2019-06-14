using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevenueForecast.Common.Models.Interfaces
{
    public interface ISowActualDetail
    {
        IEnumerable<SowDetailActualModel> GetActualSows();
        SowDetailActualModel GetActualSowDetailById(int sowDetailId);
        string SaveActualSowDetails(SowDetailActualModel sowDetailModel);
        string DeleteActualSowDetail(int sowDetailId);
    }
}

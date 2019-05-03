using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevenueForecast.Common.Models.Interfaces
{
    public interface ISowDetail
    {
        IEnumerable<SowDetailModel> Get();
        SowDetailModel GetSowDetailById(int sowDetailId);
        string SaveSowDetails(SowDetailModel sowDetailModel);
        string DeleteSowDetail(int sowDetailId);
    }
}

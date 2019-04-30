using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevenueForecast.Common.Models.Interfaces
{
    public interface ISowHeader
    {
        IEnumerable<SowHeaderModel> GetSowHeaders();
        SowHeaderModel GetSowHeaderById(int sowId);
        string SaveSowHeaderDetails(SowHeaderModel sowHeaderModel);
        string DeleteSowHeader(int sowId);
    }
}

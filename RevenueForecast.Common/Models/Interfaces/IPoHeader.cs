using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevenueForecast.Common.Models.Interfaces
{
    public interface IPoHeader
    {
        IEnumerable<PoHeaderModel> GetPoHeaders();
        PoHeaderModel GetPoHeadersById(int poId);
        string SavePoHeadersDetails(PoHeaderModel poHeaderModel);
        string DeletePoHeaders(int poId);
    }
}

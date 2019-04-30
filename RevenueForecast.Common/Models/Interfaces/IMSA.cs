using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevenueForecast.Common.Models.Interfaces
{
    public interface IMSA
    {
        IEnumerable<MSAModel> GetMSA();
        MSAModel GetMSAById(int msaId);
        string SaveMSADetails(MSAModel msaModel);
        string DeleteMSA(int msaId);
    }
}

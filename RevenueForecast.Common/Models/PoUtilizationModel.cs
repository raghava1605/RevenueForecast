using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevenueForecast.Common.Models
{
    public class PoUtilizationModel
    {
        public long PoUId { get; set; }
        public long PoDId { get; set; }
        public string PoNo { get; set; }
        public Nullable<decimal> PoMonthlyValue { get; set; }
        public int? Month { get; set; }
        public Nullable<decimal> PoBalance { get; set; }
        public Nullable<decimal> PoUtilization1 { get; set; }
    }
}

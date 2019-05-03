using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevenueForecast.Common.Models
{
    public class PoDetailsModel
    {
        public long PoDId { get; set; }
        public int PoId { get; set; }
        public System.DateTime MileStones { get; set; }
        public int? PoNo { get; set; }
        public Nullable<decimal> Amount { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevenueForecast.Common.Models
{
    public class PoDetailsModel
    {
        public long PoDetailsID { get; set; }
        public int PoHeaderID { get; set; }
        public int MileStones { get; set; }
        public Nullable<decimal> Amount { get; set; }

        public string PoNum { get; set; }
    }
}

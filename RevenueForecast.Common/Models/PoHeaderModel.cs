using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevenueForecast.Common.Models
{
    public class PoHeaderModel
    {
        public int PoHeaderID { get; set; }
        public Nullable<int> SowHeaderID { get; set; }
        public string PoNum { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public string ApprovedBy { get; set; }
        public Nullable<System.DateTime> ApprovedDate { get; set; }
        public Nullable<decimal> PoValue { get; set; }
        public string Status { get; set; }
        public Nullable<int> TotalResourceCount { get; set; }
    }
}

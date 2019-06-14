using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevenueForecast.Common.Models
{
    public class SowHeaderModel
    {
        public int SowHeaderID { get; set; }
        public string Name { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public string ApprovedBy { get; set; }
        public int CustomerID { get; set; }
        public Nullable<decimal> SowValue { get; set; }
        public Nullable<int> TotalResourceCount { get; set; }

        public string CustomerName { get; set; }
        public string Description { get; set; }
        public string Owner { get; set; }
    }
}

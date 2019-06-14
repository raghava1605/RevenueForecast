using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevenueForecast.Common.Models
{
    public class SowDetailActualModel
    {
        public long SowDetailActualID { get; set; }
        public int SowDetailID { get; set; }
        public Nullable<int> UtilizationPercentage { get; set; }
        public Nullable<decimal> TotalAmount { get; set; }
        public Nullable<int> NoOfDays { get; set; }
        public int EmployeeID { get; set; }
        public string Month { get; set; }
        public Nullable<int> Year { get; set; }
    }
}

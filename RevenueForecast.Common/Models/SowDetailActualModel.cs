using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevenueForecast.Common.Models
{
    public class SowDetailActualModel
    {
        public long Id { get; set; }
        public int SowDetailId { get; set; }
        public int? UtilizationPercentage { get; set; }
        public int? TotalAmount { get; set; }
        public int? NoOfDays { get; set; }
        public int EmpId { get; set; }
        public string Month { get; set; }
        public int? Year { get; set; }
    }
}

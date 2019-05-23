using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevenueForecast.Common.Models
{
    public class SowHeaderModel
    {
        public int SowId { get; set; }
        public string Name { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string ApprovedBy { get; set; }
        public int? CustomerId { get; set; }
        public decimal? SowValue { get; set; }
        public int? TotalResourceCount { get; set; }

        public string CustomerName { get; set; }
        public string Description { get; set; }
        public string Owner { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevenueForecast.Common.Models
{
    public class PoHeaderModel
    {
        public int PoId { get; set; }
        public int? SowId { get; set; }
        public string PoNo { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string ApprovedBy { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public long? CustomerId { get; set; }
        public decimal? Value { get; set; }
        public string Status { get; set; }
        public int? TotalResourceCount { get; set; }
    }
}

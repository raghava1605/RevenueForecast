using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevenueForecast.Common.Models
{
    public class SowDetailModel
    {
        public int SowDetailId { get; set; }
        public string SowId { get; set; }
        public string RoleName { get; set; }
        public string RoleDescription { get; set; }
        public string Location { get; set; }
        public decimal BillRate { get; set; }
        public string Currency { get; set; }
        public int HrsPerDay { get; set; }
        public System.DateTime StartDate { get; set; }
        public System.DateTime EndDate { get; set; }
        public int? UtilizationPercentage { get; set; }
        public int? SowHrsPerDay { get; set; }
        public Nullable<decimal> SowAmount { get; set; }
        public Nullable<decimal> CalculatedAmount { get; set; }
    }
}

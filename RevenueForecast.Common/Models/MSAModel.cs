using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevenueForecast.Common.Models
{
    public class MSAModel
    {
        public int MSAId { get; set; }
        public int CustomerId { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public string MSAEntity { get; set; }
        public string ContractType { get; set; }

        public string CustomerName { get; set; }
        public string Description { get; set; }
        public string Owner { get; set; }
    }
}

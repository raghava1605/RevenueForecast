//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RevenueForecast.Common.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class SowDetailActual
    {
        public long SowDetailActualID { get; set; }
        public int SowDetailID { get; set; }
        public Nullable<int> UtilizationPercentage { get; set; }
        public Nullable<int> TotalAmount { get; set; }
        public Nullable<int> NoOfDays { get; set; }
        public string Month { get; set; }
        public Nullable<int> Year { get; set; }
        public int EmployeeID { get; set; }
    
        public virtual Employee Employee { get; set; }
        public virtual SowDetail SowDetail { get; set; }
    }
}

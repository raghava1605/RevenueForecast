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
    
    public partial class PoUtilization
    {
        public long PoUId { get; set; }
        public long PoDId { get; set; }
        public string PoNo { get; set; }
        public Nullable<decimal> PoMonthlyValue { get; set; }
        public int? Month { get; set; }
        public Nullable<decimal> PoBalance { get; set; }
        public Nullable<decimal> PoUtilization1 { get; set; }
    
        public virtual PoDetail PoDetail { get; set; }
    }
}

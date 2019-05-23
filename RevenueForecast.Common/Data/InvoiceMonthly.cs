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
    
    public partial class InvoiceMonthly
    {
        public long Id { get; set; }
        public string InvoiceNo { get; set; }
        public Nullable<long> ActualSowDetailId { get; set; }
        public string SowId { get; set; }
        public int HoursMonthly { get; set; }
        public Nullable<System.DateTime> SubmittedDate { get; set; }
        public Nullable<System.DateTime> ReceivedDate { get; set; }
        public Nullable<int> Month { get; set; }
        public Nullable<int> Year { get; set; }
        public Nullable<decimal> AdjustedAmount { get; set; }
        public Nullable<decimal> TotalAmount { get; set; }
        public string PONo { get; set; }
    
        public virtual SowDetailActual SowDetailActual { get; set; }
    }
}

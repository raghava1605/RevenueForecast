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
    
    public partial class PoHeader
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PoHeader()
        {
            this.PoDetails = new HashSet<PoDetail>();
        }
    
        public int PoId { get; set; }
        public Nullable<int> SowId { get; set; }
        public string PoNo { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public string ApprovedBy { get; set; }
        public Nullable<System.DateTime> ApprovedDate { get; set; }
        public Nullable<long> CustomerId { get; set; }
        public Nullable<decimal> Value { get; set; }
        public string Status { get; set; }
        public Nullable<int> TotalResourceCount { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PoDetail> PoDetails { get; set; }
        public virtual SowHeader SowHeader { get; set; }
    }
}
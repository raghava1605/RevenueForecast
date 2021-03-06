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
    
    public partial class SowDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SowDetail()
        {
            this.SowDetailActuals = new HashSet<SowDetailActual>();
        }
    
        public int SowDetailID { get; set; }
        public int SowHeaderID { get; set; }
        public decimal BillRate { get; set; }
        public string Currency { get; set; }
        public int HrsPerDay { get; set; }
        public System.DateTime StartDate { get; set; }
        public System.DateTime EndDate { get; set; }
        public Nullable<int> UtilizationPercentage { get; set; }
        public Nullable<int> SowHrsPerDay { get; set; }
        public Nullable<decimal> SowAmount { get; set; }
        public Nullable<int> EmployeeID { get; set; }
    
        public virtual Employee Employee { get; set; }
        public virtual SowHeader SowHeader { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SowDetailActual> SowDetailActuals { get; set; }
    }
}

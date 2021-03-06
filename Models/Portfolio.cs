//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MetopeOrdersTest.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Portfolio
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Portfolio()
        {
            this.Portfolio_List = new HashSet<Portfolio_List>();
            this.Order_Allocation = new HashSet<Order_Allocation>();
        }
    
        public decimal Entity_ID { get; set; }
        public string Portfolio_Code { get; set; }
        public string Portfolio_Name { get; set; }
        public string Manager { get; set; }
        public string Portfolio_Type { get; set; }
        public string Portfolio_Base_Currency { get; set; }
        public string PortfolIo_Domicile { get; set; }
        public string Portfolio_Report_Currency { get; set; }
        public Nullable<System.DateTime> Inception_Date { get; set; }
        public Nullable<System.DateTime> Financial_Year_End { get; set; }
        public string Custodian_Code { get; set; }
        public bool Active_Flag { get; set; }
        public Nullable<bool> System_Locked { get; set; }
        public string Portfolio_Status { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Portfolio_List> Portfolio_List { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order_Allocation> Order_Allocation { get; set; }
    }
}

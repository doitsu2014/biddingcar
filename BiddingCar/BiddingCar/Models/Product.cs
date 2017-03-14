//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BiddingCar.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            this.Bidies = new HashSet<Bidy>();
        }
    
        public string IdProduct { get; set; }
        public string Name { get; set; }
        public double MinPrice { get; set; }
        public string BaseDescription { get; set; }
        public System.DateTime TimeBegin { get; set; }
        public System.DateTime TimeEnd { get; set; }
        public double MinPriceStep { get; set; }
        public string ImageURL { get; set; }
        public int Status { get; set; }
        public Nullable<double> FirstPrice { get; set; }
        public string CategoryID { get; set; }
        public Nullable<double> TopPrice { get; set; }
        public Nullable<int> BidyCount { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bidy> Bidies { get; set; }
        public virtual Category Category { get; set; }
    }
}
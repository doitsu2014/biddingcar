using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BiddingCar.Models
{
    public class ProductViewModel
    {
        public string IdProduct { get; set; }
        public string Name { get; set; }
        public double MinPrice { get; set; }
        public string BaseDescription { get; set; }
        public System.DateTime TimeBegin { get; set; }
        public System.DateTime TimeEnd { get; set; }
        public double MinPriceStep { get; set; }
        public string ImageURL { get; set; }
        public Nullable<double> FirstPrice { get; set; }
        public string CategoryID { get; set; }
        public Nullable<double> TopPrice { get; set; }
        public Nullable<int> BidyCount { get; set; }
        public bool Status { get; set; }
        public string TopBider { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace ABCIntegration.BEANS
{

    public class ParcelBEAN
    {
        [Display(Name = "Parcel ID")]
        public int parcel_id { get; set; }
        [Display(Name = "Type")]
        public string type { get; set; }
        [Display(Name = "Weight")]
        public Nullable<double> weight { get; set; }
        [Display(Name = "Height")]
        public Nullable<double> Height { get; set; }
        [Display(Name = "Width")]
        public string width { get; set; }
        [Display(Name = "Description")]
        public string description { get; set; }
        [Display(Name = "Branch Code")]
        public string branch_code { get; set; }
        [Display(Name = "Delivery Address L1")]
        public string shipping_addy_line1 { get; set; }
        [Display(Name = "Delivery Address L2")]
        public string shipping_addy_line2 { get; set; }
        [Display(Name = "City")]
        public string shipping_city { get; set; }
        [Display(Name = "County")]
        public string shipping_county { get; set; }
        [Display(Name = "Country")]
        public string shipping_country { get; set; }
        [Display(Name = "PostCode")]
        public string shipping_postcode { get; set; }
        [Display(Name = "Tracking ID")]
        public string tracking_id { get; set; }
        [Display(Name = "Shipping Mode")]
        public string shipping_mode { get; set; }
        [Display(Name = "Date Created")]
        public Nullable<System.DateTime> date_create { get; set; }
        [Display(Name = "Creator ID")]
        public Nullable<int> creator_id { get; set; }
    }
}

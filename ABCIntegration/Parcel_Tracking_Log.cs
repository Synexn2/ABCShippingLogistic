//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ABCIntegration
{
    using System;
    using System.Collections.Generic;
    
    public partial class Parcel_Tracking_Log
    {
        public int Id { get; set; }
        public string tracking_id { get; set; }
        public string branch_code { get; set; }
        public System.DateTime date { get; set; }
        public string remarks { get; set; }
        public int parcel_id { get; set; }
        public string location { get; set; }
    }
}

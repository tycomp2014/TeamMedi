//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcWebAPI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Ambulance
    {
        public int AmbulanceID { get; set; }
        public int CallCentreID { get; set; }
        public Nullable<double> lat { get; set; }
        public Nullable<double> lon { get; set; }
    
        public virtual CallCentre CallCentre { get; set; }
    }
}

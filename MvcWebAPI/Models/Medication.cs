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
    
    public partial class Medication
    {
        public Medication()
        {
            this.Patients = new HashSet<Patient>();
        }
    
        public int MedicationID { get; set; }
        public string MedicationName { get; set; }
        public Nullable<decimal> Grams { get; set; }
        public Nullable<decimal> ml { get; set; }
        public string Details { get; set; }
    
        public virtual ICollection<Patient> Patients { get; set; }
    }
}

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
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
    
    public partial class ViewPatient
    {
        public int PatientID { get; set; }
        public int MedicationID { get; set; }
        public int GPID { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }
        [DataType(DataType.Date),
        DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public System.DateTime DOB { get; set; }
        public string Medication { get; set; }
        public string Alergies { get; set; }
        public string MedicationHistory { get; set; }
    }
}

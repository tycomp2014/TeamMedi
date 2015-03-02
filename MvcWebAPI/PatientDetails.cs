using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcWebAPI.Models;


namespace MvcWebAPI
{
    public partial class PatientDetails
    {
        public PatientDetails()
        {
            this.MedicationHistories = new HashSet<MedicationHistory>();
            this.Medications = new HashSet<Medication>();
        }
        public int PatientID { get; set; }
        public int MedicationID { get; set; }
        public int GPID { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public System.DateTime DOB { get; set; }
        public string Medication { get; set; }


        public virtual GP GP { get; set; }
        public virtual ICollection<MedicationHistory> MedicationHistories { get; set; }
        public virtual ICollection<Medication> Medications { get; set; }
    }
}
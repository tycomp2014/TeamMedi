﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Objects;
    using System.Data.Objects.DataClasses;
    using System.Linq;
    
    public partial class mydbEntities : DbContext
    {
        public mydbEntities()
            : base("name=mydbEntities")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Ambulance> Ambulances { get; set; }
        public DbSet<CallCentre> CallCentres { get; set; }
        public DbSet<GP> GPs { get; set; }
        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<Medication> Medications { get; set; }
        public DbSet<MedicationHistory> MedicationHistories { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<PatientCall> PatientCalls { get; set; }
        public DbSet<ViewPatient> ViewPatients { get; set; }
    
        public virtual int calcDistance(Nullable<double> lat, Nullable<double> lon, Nullable<double> kilometers)
        {
            var latParameter = lat.HasValue ?
                new ObjectParameter("lat", lat) :
                new ObjectParameter("lat", typeof(double));
    
            var lonParameter = lon.HasValue ?
                new ObjectParameter("lon", lon) :
                new ObjectParameter("lon", typeof(double));
    
            var kilometersParameter = kilometers.HasValue ?
                new ObjectParameter("Kilometers", kilometers) :
                new ObjectParameter("Kilometers", typeof(double));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("calcDistance", latParameter, lonParameter, kilometersParameter);
        }
    
        public virtual int CallCentreProc(Nullable<double> e_PatientLat, Nullable<double> e_PatientLon, Nullable<double> e_AmbulanceLat, Nullable<double> e_AmbulanceLon, Nullable<int> e_AmbulanceID, Nullable<int> e_PatientID)
        {
            var e_PatientLatParameter = e_PatientLat.HasValue ?
                new ObjectParameter("E_PatientLat", e_PatientLat) :
                new ObjectParameter("E_PatientLat", typeof(double));
    
            var e_PatientLonParameter = e_PatientLon.HasValue ?
                new ObjectParameter("E_PatientLon", e_PatientLon) :
                new ObjectParameter("E_PatientLon", typeof(double));
    
            var e_AmbulanceLatParameter = e_AmbulanceLat.HasValue ?
                new ObjectParameter("E_AmbulanceLat", e_AmbulanceLat) :
                new ObjectParameter("E_AmbulanceLat", typeof(double));
    
            var e_AmbulanceLonParameter = e_AmbulanceLon.HasValue ?
                new ObjectParameter("E_AmbulanceLon", e_AmbulanceLon) :
                new ObjectParameter("E_AmbulanceLon", typeof(double));
    
            var e_AmbulanceIDParameter = e_AmbulanceID.HasValue ?
                new ObjectParameter("E_AmbulanceID", e_AmbulanceID) :
                new ObjectParameter("E_AmbulanceID", typeof(int));
    
            var e_PatientIDParameter = e_PatientID.HasValue ?
                new ObjectParameter("E_PatientID", e_PatientID) :
                new ObjectParameter("E_PatientID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CallCentreProc", e_PatientLatParameter, e_PatientLonParameter, e_AmbulanceLatParameter, e_AmbulanceLonParameter, e_AmbulanceIDParameter, e_PatientIDParameter);
        }
    }
}

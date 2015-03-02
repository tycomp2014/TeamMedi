using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using MvcWebAPI.Models;

namespace MvcWebAPI.Controllers
{
    public class PatientController : ApiController
    {
        private mydbEntities db = new mydbEntities();

        // GET api/Patient
        public IEnumerable<Patient> GetPatients()
        {
            var patients = db.Patients;
            return patients;
        }

        // GET api/Patient/5
        public Patient GetPatient(int id)
        {
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.BadRequest));
            }


            return patient;
        }

        // PUT api/Patient/5
        public HttpResponseMessage PutPatient(int id, Patient patient)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != patient.PatientID)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(patient).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST api/Patient
        public HttpResponseMessage PostPatient(Patient patient)
        {
            if (ModelState.IsValid)
            {
                db.Patients.Add(patient);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, patient);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = patient.PatientID }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Patient/5
        public HttpResponseMessage DeletePatient(int id)
        {
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Patients.Remove(patient);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, patient);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
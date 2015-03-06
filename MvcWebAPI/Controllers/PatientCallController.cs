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
    public class PatientCallController : ApiController
    {
        private mydbEntities db = new mydbEntities();

        // GET api/PatientCall
        public IEnumerable<PatientCall> GetPatientCalls()
        {
            var patientcalls = db.PatientCalls.Include(p => p.Patient);
            return patientcalls.AsEnumerable();
        }

        // GET api/PatientCall/5
        public PatientCall GetPatientCall(int id)
        {
            PatientCall patientcall = db.PatientCalls.Find(id);
            if (patientcall == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return patientcall;
        }

        // PUT api/PatientCall/5
        public HttpResponseMessage PutPatientCall(int id, PatientCall patientcall)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != patientcall.PatientCallsID)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(patientcall).State = EntityState.Modified;

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

        // POST api/PatientCall
        public HttpResponseMessage PostPatientCall(PatientCall patientcall)
        {
            if (ModelState.IsValid)
            {

              //  try
               // {
                    db.PatientCalls.Add(patientcall);
                    db.SaveChanges();
               // }
                //catch (Exception e)
                //{
                //    new HttpResponseException(Request.CreateResponse(HttpStatusCode.BadRequest));
                //}
               

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, patientcall);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = patientcall.PatientCallsID }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/PatientCall/5
        public HttpResponseMessage DeletePatientCall(int id)
        {
            PatientCall patientcall = db.PatientCalls.Find(id);
            if (patientcall == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.PatientCalls.Remove(patientcall);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, patientcall);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
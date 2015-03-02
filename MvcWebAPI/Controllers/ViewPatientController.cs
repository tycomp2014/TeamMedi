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
using System.Data.Entity.Validation;

using System.Diagnostics; 
using MvcWebAPI.Models;


namespace MvcWebAPI.Controllers
{
    public class ViewPatientController : ApiController
    {
        private mydbEntities db = new mydbEntities();

        // GET api/ViewPatient
        public IEnumerable<ViewPatient> GetViewPatients()
        {
            return db.ViewPatients;
        }

        // GET api/ViewPatient/5
        public dynamic GetViewPatient(int id)
        {
            ViewPatient viewpatient = db.ViewPatients.Find(id);

            //try
            //{
            //    return viewpatient;
            //}
            //catch (Exception e)
            //{
                if (viewpatient == null)
                {
                    return new HttpResponseException(Request.CreateResponse(HttpStatusCode.BadRequest));
                }
                // error handling logic
            //}
           
                return viewpatient;
            
        }

        // PUT api/ViewPatient/5
        public HttpResponseMessage PutViewPatient(int id, ViewPatient viewpatient)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != viewpatient.PatientID)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(viewpatient).State = EntityState.Modified;

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

        // POST api/ViewPatient
        public HttpResponseMessage PostViewPatient(ViewPatient viewpatient)
        {
            if (ModelState.IsValid)
            {
                db.ViewPatients.Add(viewpatient);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, viewpatient);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = viewpatient.PatientID }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/ViewPatient/5
        public HttpResponseMessage DeleteViewPatient(int id)
        {
            ViewPatient viewpatient = db.ViewPatients.Find(id);
            if (viewpatient == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.ViewPatients.Remove(viewpatient);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, viewpatient);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MvcWebAPI.Models;

namespace MvcWebAPI.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        private mydbEntities db = new mydbEntities();

        // GET api/Patient
        public IEnumerable<Patient> GetPatients()
        {
            return db.Patients;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
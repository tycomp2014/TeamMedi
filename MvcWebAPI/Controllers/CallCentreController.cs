using MvcWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcWebAPI.Controllers
{
    public class CallCentreController : Controller
    {

        //
        // GET: /CallCentre/

        public ActionResult Index()
        {
            var mydbEntities = new mydbEntities();
            var patient = from p in mydbEntities.Patients
                          select p;
            return View();
        }

        //
        // GET: /CallCentre/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /CallCentre/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /CallCentre/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /CallCentre/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /CallCentre/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /CallCentre/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /CallCentre/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

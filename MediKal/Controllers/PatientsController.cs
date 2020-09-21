using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BE;
using BL;
using MediKal.Models;

namespace MediKal.Controllers
{
    public class PatientsController : Controller
    {
        // GET: Patients
        public ActionResult Index()
        {
            IBL bl = new BL.BL();
            var patients = bl.GetPatients().Select(item => new PatientViewModel(item));
            return View(patients);
        }

        // GET: Patients/Details/5
        public ActionResult Details(int id)
        {
            IBL bl = new BL.BL();
            Patient patient = bl.GetPatientById(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(new PatientViewModel(patient));
        }

        // GET: Patients/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Patients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FullName,Birthday,Background,BloodType,Phone,Mail")] Patient patient)
        {
            if (ModelState.IsValid)
            {
                IBL bl = new BL.BL();
                bl.AddPatient(patient);
                return RedirectToAction("Index");
            }

            return View(new PatientViewModel(patient));
        }

        // GET: Patients/Edit/5
        public ActionResult Edit(int id)
        {
            IBL bl = new BL.BL();
            Patient patient = bl.GetPatientById(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(new PatientViewModel(patient));
        }

        // POST: Patients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Patient patient, int Id)
        {
            if (ModelState.IsValid)
            {
                IBL bl = new BL.BL();
                bl.UpdatePatient(patient,Id);
                return RedirectToAction("Index");
            }
            return View(new PatientViewModel(patient));
        }

        // GET: Patients/Delete/5
        public ActionResult Delete(int id)
        {
            IBL bl = new BL.BL();
            Patient patient = bl.GetPatientById(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(new PatientViewModel(patient));
        }

        // POST: Patients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            IBL bl = new BL.BL();
            bl.DeletePatient(id);
            return RedirectToAction("Index");
        }

    }
}

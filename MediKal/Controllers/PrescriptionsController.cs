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
    public class PrescriptionsController : Controller
    {

        // GET: Prescriptions
        public ActionResult Index()
        {
            IBL bl = new BL.BL();
            var prescriptions = bl.GetPrescriptions().Select(item => new PrescriptionViewModel(item));
            return View(prescriptions);
        }

        // GET: Prescriptions/Details/5
        public ActionResult Details(int id)
        {
            IBL bl = new BL.BL();
            Prescription prescription = bl.GetPrescriptionById(id);
            if (prescription == null)
            {
                return HttpNotFound();
            }
            return View(new PrescriptionViewModel(prescription));
        }

        // GET: Prescriptions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Prescriptions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Prescription prescription)
        {
            if (ModelState.IsValid)
            {
                IBL bl = new BL.BL();
                bl.AddPrescription(prescription);
                return RedirectToAction("Index");
            }

            return View(new PrescriptionViewModel(prescription));
        }

        // GET: Prescriptions/Edit/5
        public ActionResult Edit(int id)
        {
            IBL bl = new BL.BL();
            Prescription prescription = bl.GetPrescriptionById(id);
            if (prescription == null)
            {
                return HttpNotFound();
            }
            return View(new PrescriptionViewModel(prescription));
        }

        // POST: Prescriptions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Prescription prescription, int Id)
        {
            if (ModelState.IsValid)
            {
                IBL bl = new BL.BL();
                bl.UpdatePrescription(prescription,Id);
                return RedirectToAction("Index");
            }
            return View(new PrescriptionViewModel(prescription));
        }

        // GET: Prescriptions/Delete/5
        public ActionResult Delete(int id)
        {
            IBL bl = new BL.BL();
            Prescription prescription = bl.GetPrescriptionById(id);
            if (prescription == null)
            {
                return HttpNotFound();
            }
            return View(new PrescriptionViewModel(prescription));
        }

        // POST: Prescriptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            IBL bl = new BL.BL();
            bl.DeletePrescription(id);
            return RedirectToAction("Index");
        }

        public ActionResult PdfViewer(int id)
        {
            IBL bl = new BL.BL();
            var prescription = bl.GetPrescriptionById(id);
            if (prescription == null)
                return View("Error");
            return View(new PrescriptionViewModel(prescription));
        }
    }
}

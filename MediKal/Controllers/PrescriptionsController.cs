﻿using System;
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
            if (RouteConfig.user == null)
                return View("Error");
            IEnumerable<PrescriptionViewModel> prescriptions;
            if (RouteConfig.user.UserType == UserTypeEnum.Manager)
                prescriptions = bl.GetPrescriptions().Select(item => new PrescriptionViewModel(item));
            else if (RouteConfig.user.UserType == UserTypeEnum.Doctor)
                prescriptions = bl.GetPrescriptionsOfDoctor(RouteConfig.user.PrimaryId).Select(item => new PrescriptionViewModel(item));
            else
                prescriptions = bl.GetPrescriptionsOfPatient(RouteConfig.user.PrimaryId).Select(item => new PrescriptionViewModel(item));
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
                prescription.PrescriptionDate = DateTime.Now;
                bl.AddPrescription(prescription);
                string link = $"http://{Request.Url.Host}:{Request.Url.Port}/Account/SignIn";
                Patient patient = prescription.GetPatient();
                bl.SendSMS(patient.Phone, patient.UserName, "You have a new prescription!");
                bl.SendMail(patient.Mail, patient.UserName, $"You have a new prescription!\n<a href='{link}'> Go to your account </a>");
                return PdfViewer(prescription.Id);
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
            return View("PdfViewer", new PrescriptionViewModel(prescription));
        }

        public ActionResult ChoosePatient()
        {
            IBL bl = new BL.BL();
            ViewBag.IsSelectView = true;
            return View("~/Views/Patients/Index.cshtml", bl.GetPatients());
        }
        public ActionResult AddPrescriptionToPatient(int patientId)
        {
            IBL bl = new BL.BL();
            var primaryDoctorId = bl.GetDoctorById(RouteConfig.user.Id).PrimaryId;
            Prescription prescription = new Prescription()
            {
                PatientId = patientId,
                DoctorId = primaryDoctorId };

            return View("Create", new PrescriptionViewModel(prescription));
        }
    }
}

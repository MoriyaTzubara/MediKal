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
        [HttpPost]
        public ActionResult GetWarningsByJson(int medicineId, int patientId)
        {
            IBL bl = new BL.BL();
            string NDCId = bl.GetMedicineByPrimaryId(medicineId).NDCId;
            List<string> medicines = bl.GetMedicinesOfPatient(patientId).ToList();
            medicines.Add(NDCId);
            DrugIntractionLogic drugIntractionLogic = new DrugIntractionLogic();
            List<string> warningsStrings = new List<string>();
            warningsStrings = drugIntractionLogic.checkInteractions(medicines);
            Warning warning = new Warning();
            if (warningsStrings.Count() == 1)
            {
                return Json(new List<Warning>(), JsonRequestBehavior.AllowGet);
            }
            warning.ConflictingMedicines = warningsStrings[0];
            warning.LevelOfRisk = warningsStrings[1];
            warning.Description = warningsStrings[2];
            string[] helper = warning.Description.Split('.');
            warning.Description = helper[0];
            var result = new List<Warning>();
            result.Add(warning);
            return Json(result, JsonRequestBehavior.AllowGet);
        }


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
                DoctorId = primaryDoctorId
            };

            return View("Create", new PrescriptionViewModel(prescription));
        }
    }
}

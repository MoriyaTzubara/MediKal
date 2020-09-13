using BE;
using MediKal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MediKal.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        // FOR MANAGEMENT
        public ActionResult AddMedicine()
        {
            return View();
        }
        // FOR MANAGEMENT
        public ActionResult DeleteMedicine()
        {
            return View();
        }
        // FOR MANAGEMENT
        public ActionResult UpdateMedicine()
        {
            return View();
        }
        // FOR MANAGEMENT
        public ActionResult AllMedicines()
        {
            return View();
        }
        // FOR PATIENT
        public ActionResult MyMedicines()
        {
            return View();
        }
        // FOR MANAGEMENT
        public ActionResult MedicineChart()
        {
            return View();
        }
        // FOR DOCTOR
        public ActionResult AddPrescription()
        {
            return View();
        }
        // FOR DOCTOR
        public ActionResult DeletePrescription()
        {
            return View();
        }
        // FOR DOCTOR
        public ActionResult UpdatePrescription()
        {
            return View();
        }
        // FOR MANAGEMENT AND DOCTOR
        public ActionResult AllPrescriptions()
        {
            return View();
        }
        // FOR PATIENT
        public ActionResult MyPrescriptions()
        {
            return View();
        }
        //FOR DOCTOR
        public ActionResult PatientHistory()
        {
            return View();
        }
        // FOR DOCTOR
        public ActionResult AllPatients()
        {
            return View();
        }
    }
}
using BE;
using BL;
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
        [HttpGet]
        public ActionResult SignIn()
        {
            return View();
        }
        public ActionResult EnterId()
        {
            return View();
        }
        public ActionResult EnterCode(int Id)
        {
            IBL bl = new BL.BL();
            var doctor = bl.GetDoctorById(Id);
            if (doctor == null)
            {
                return View("Error");
            }
            return View(new DoctorViewModel(doctor));
        }
        [HttpPost]
        public ActionResult SignIn(int Id, string Password)
        {
            try
            {
                IBL bl = new BL.BL();
                User user = bl.SignIn(Id, Password);
                RouteConfig.user = user;
                return Redirect("~/Account");

            }
            catch (Exception e) { return View(e.Message); }
        }
        [HttpGet]
        public ActionResult SignUp(int Id)
        {
            IBL bl = new BL.BL();
            var doctor = bl.GetDoctorById(Id);
            if (doctor == null)
            {
                return View("Error");
            }
            return View(new DoctorViewModel(doctor));
        }
        [HttpPost]
        public ActionResult SignUp(DoctorViewModel doctorViewModel)
        {
            try
            {
                IBL bl = new BL.BL();
                User user = bl.GetUserById(doctorViewModel.Id);
                //which view you want him to go to
                return View();
            }
            catch (ArgumentNullException) { return View(); }
        }
        //public ActionResult EditPersonalDetails(Patient user,int Id)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        IBL bl = new BL.BL();
        //        if(user.UserType == UserTypeEnum.Doctor)
        //        bl.UpdateDoctor(user, Id);
        //        return RedirectToAction("Index");
        //    }
        //    return View(new PatientViewModel(patient));
        //}
        public ActionResult SignOut()
        {
            return RedirectToAction("Index","Home");
        }
    }
}
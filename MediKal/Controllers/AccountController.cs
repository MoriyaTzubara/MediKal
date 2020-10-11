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
            var user = bl.GetUserById(Id);
            if (user == null)
            {
                return View("Error");
            }
            string code = "1234";
            Session["CorrectCode"] = code;
            return View(new UserViewModel(user));
        }
        public ActionResult CheckCode(string CorrectCode, string Code,User user)
        {
            IBL bl = new BL.BL();
            //sending error
            if (CorrectCode != Code)
                return View();
            //correct
            if (user.UserType == UserTypeEnum.Doctor)
                return View("SignUpDoctor",new DoctorViewModel(bl.ConvertUserToDoctor(user)));
            return View("SignUpPatient",new PatientViewModel(bl.ConvertUserToPatient(user)));
        }
        [HttpPost]
        public ActionResult SignIn(int Id, string Password)
        {
            try
            {
                IBL bl = new BL.BL();
                User user = bl.SignIn(Id, Password);
                RouteConfig.user = user;
                return View("Index");

            }
            catch (Exception e) { return View(e.Message); }
        }

        [HttpGet]
        public ActionResult SignUp()
        {
            return View("EnterId");
        }
        [HttpGet]
        //public ActionResult SignUp(int Id)
        //{
        //    IBL bl = new BL.BL();
        //    var doctor = bl.GetDoctorById(Id);
        //    if (doctor == null)
        //    {
        //        return View("Error");
        //    }
        //    return View(new DoctorViewModel(doctor));
        //}
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
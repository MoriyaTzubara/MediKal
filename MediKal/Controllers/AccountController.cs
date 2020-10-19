using BE;
using BL;
using DAL;
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
            Session["Error"] = "";
            return View();
        }
        public ActionResult EnterId()
        {
            Session["Error"] = "";
            return View();
        }
        public ActionResult EnterCode(int Id)
        {
            Session["Error"] = "";
            IBL bl = new BL.BL();
            var user = bl.GetUserById(Id);
            if (!Validation.IsId(Id))
            {
                Session["Error"] = "Id isn't valid";
                return View("EnterId");
            }
            if (user == null || user.UserName != null || user.Password != null)
            {
                Session["Error"] = "You are already registered";
                return View("EnterId");
            }
            Random random = new Random();
            int code = random.Next(10000, 100000);
            bl.SendMail(user.Mail, user.UserName, code.ToString());
            Session["CorrectCode"] = code;
            return View(new UserViewModel(user));
        }
        public ActionResult CheckCode(string CorrectCode, string Code,User user)
        {
            IBL bl = new BL.BL();
            //sending error
            if (CorrectCode != Code)
            {
                Session["Error"] = "please try again!";
                return View("EnterCode",new UserViewModel(user));
            }
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
            catch (Exception e) {
                Session["Error"] = e.Message;
                return View(); 
            }
        }
        [HttpPost]
        public ActionResult SignUpDoctor(Doctor doctor)
        {
            try
            {
                IBL bl = new BL.BL();
                bl.UpdateDoctor(doctor,doctor.Id);
                RouteConfig.user = bl.SignIn(doctor.Id, doctor.Password);
                //which view you want him to go to
                return View("Index");
            }
            catch (ArgumentNullException) { return View(); }
        }

        [HttpPost]
        public ActionResult SignUpPatient(Patient patient)
        {
            try
            {
                IBL bl = new BL.BL();
                bl.UpdatePatient(patient, patient.Id);
                RouteConfig.user = bl.SignIn(patient.Id, patient.Password);
                //which view you want him to go to
                return View("Index");
            }
            catch (ArgumentNullException) { return View(); }
        }
        // GET: Patients/Edit/5
        public ActionResult EditPersonalDetails()
        {
            IBL bl = new BL.BL();
            if (RouteConfig.user == null)
            {
                return HttpNotFound();
            }
            Session["Error"] = "";
            return View(new UserViewModel(RouteConfig.user));
        }

        // POST: Patients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPersonalDetails(User user, int Id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    IBL bl = new BL.BL();
                    if (user.UserType == UserTypeEnum.Doctor)
                        bl.UpdateDoctor(bl.ConvertUserToDoctor(user), Id);
                    if (user.UserType == UserTypeEnum.Patient)
                        bl.UpdatePatient(bl.ConvertUserToPatient(user), Id);
                    RouteConfig.user = user;
                    return RedirectToAction("Index", "Account");
                }
                return View(new UserViewModel(user));
            }catch(Exception e) { 
                Session["Error"] = e.Message;
                return View(new UserViewModel(user));
            }
        }
        public ActionResult SignOut()
        {
            RouteConfig.user = null;
            return RedirectToAction("Index","Home");
        }
    }
}

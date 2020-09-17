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
        [HttpGet]
        public ActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignIn(string Mail, string Password)
        {
            return Redirect("~/Account");
        }
        public ActionResult SignUp()
        {
            return View();
        }
        public ActionResult SignOut()
        {
            return RedirectToAction("Index","Home");
        }
    }
}
using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MediKal.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //BL.CRUDdrugs bl = new BL.CRUDdrugs();
            //bool Result = bl.AddDrug(new Medicine { ActiveIngredients = "", Company = "", GenericName = "", ImagePath = "", Name = "" });
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
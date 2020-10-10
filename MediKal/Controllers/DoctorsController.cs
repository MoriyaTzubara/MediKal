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
    public class DoctorsController : Controller
    {

        // GET: Doctors
        public ActionResult Index()
        {
            IBL bl = new BL.BL();
            var doctors = bl.GetDoctors();
            return View(doctors);
        }

        // GET: Doctors/Details/5
        public ActionResult Details(int id)
        {
            IBL bl = new BL.BL();

            if (id == -1)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctor doctor =(Doctor) bl.GetDoctorById(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }
            return View(doctor);
        }

        // GET: Doctors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Doctors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,LicenseNum,Specialty,UserName,Password,Phone,Mail,Birthday,UserType")] Doctor doctor)
        {
            IBL bl = new BL.BL();
            //doctor.PersonId = 211466370;
            if (ModelState.IsValid)
            {
                bl.AddDoctor(doctor);
                return RedirectToAction("Index");
            }
            return View(doctor);
        }

        // GET: Doctors/Edit/5
        public ActionResult Edit(int id)
        {
            IBL bl = new BL.BL();

            if (id == -1)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctor doctor = bl.GetDoctorById(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }
            return View(doctor);
        }

        // POST: Doctors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,LicenseNum,Specialty,UserName,Password,Phone,Mail,Birthday,UserType")] Doctor doctor)
        {
            IBL bl = new BL.BL();

            if (ModelState.IsValid)
            {
                bl.UpdateDoctor(doctor, doctor.Id);
                return RedirectToAction("Index");
            }
            return View(doctor);
        }

        // GET: Doctors/Delete/5
        public ActionResult Delete(int id)
        {
            IBL bl = new BL.BL();

            if (id == -1)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctor doctor = bl.GetDoctorById(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }
            return View(doctor);
        }

        // POST: Doctors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            IBL bl = new BL.BL();

            bl.DeleteDoctor(id);
            return RedirectToAction("Index");
        }
    }
}

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
    public class MedicinesController : Controller
    {
        // GET: Medicines
        public ActionResult Index()
        {
            IBL bl = new BL.BL();
            //bl.ReadExcelMedicines("", 1);
            var medicines = bl.GetMedicines().Select(item => new MedicineViewModel(item));
            return View(medicines);
        }

        // GET: Medicines/Details/5
        public ActionResult Details(double id)
        {
            IBL bl = new BL.BL();
            Medicine medicine = bl.GetMedicineById(id);
            if (medicine == null)
            {
                return HttpNotFound();
            }
            return View(new MedicineViewModel(medicine));
        }

        // GET: Medicines/Create
        public ActionResult Create()
        {
            Session["Message"] = "";
            return View();
        }

        // POST: Medicines/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Medicine medicine)
        {
            try
            {
                IBL bl = new BL.BL();
                bl.AddMedicine(medicine);
                return RedirectToAction("Index");
            }catch(Exception e) { return View(); }
        }

        // GET: Medicines/Edit/5
        public ActionResult Edit(double id)
        {
            IBL bl = new BL.BL();
            Medicine medicine = bl.GetMedicineById(id);
            if (medicine == null)
            {
                return HttpNotFound();
            }
            return View(new MedicineViewModel(medicine));
        }

        // POST: Medicines/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Medicine medicine)
        {
            if (ModelState.IsValid)
            {
                IBL bl = new BL.BL();
                bl.UpdateMedicine(medicine,medicine.NDCId);
                return RedirectToAction("Index");
            }
            return View(new MedicineViewModel(medicine));
        }

        // GET: Medicines/Delete/5
        public ActionResult Delete(double id)
        {
            IBL bl = new BL.BL();
            Medicine medicine = bl.GetMedicineById(id);
            if (medicine == null)
            {
                return HttpNotFound();
            }
            return View(new MedicineViewModel(medicine));
        }

        // POST: Medicines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(double id)
        {
            IBL bl = new BL.BL();
            Medicine medicine = bl.GetMedicineById(id);
            if (medicine == null)
            {
                return HttpNotFound();
            }
            bl.DeleteMedicine(id);
            return RedirectToAction("Index");
        }

        public ActionResult AddImage(string id)
        {
            IBL bl = new BL.BL();
            Medicine medicine = bl.FindMedicineInExcel(id);
            if (medicine == null)
            {
                Session["Message"] = "NDCId not found";
                return View("Create");
            }
            if(bl.GetMedicineById(medicine.NDCId)!=null)
            {
                Session["Message"] = "The medicine already exists";
                return View("Create");
            }
            else 
            return View("AddImage",new MedicineViewModel(medicine));
        }
    }
}

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
      //      var medicines = bl.GetMedicines().Select(item => new MedicineViewModel(item));
            bl.ReadExcelMedicines("",1);
            return View(medicines);
        }

        // GET: Medicines/Details/5
        public ActionResult Details(int id)
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
            return View();
        }

        // POST: Medicines/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,GenericName,Name,ImagePath,Company")] Medicine medicine)
        {
            if (ModelState.IsValid)
            {
                IBL bl = new BL.BL();
                bl.AddMedicine(medicine);
                return RedirectToAction("Index");
            }
            return View(medicine);
        }

        // GET: Medicines/Edit/5
        public ActionResult Edit(int id)
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
        public ActionResult Edit(Medicine medicine,int Id)
        {
            if (ModelState.IsValid)
            {
                IBL bl = new BL.BL();
                bl.UpdateMedicine(medicine,Id);
                return RedirectToAction("Index");
            }
            return View(new MedicineViewModel(medicine));
        }

        // GET: Medicines/Delete/5
        public ActionResult Delete(int id)
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
        public ActionResult DeleteConfirmed(int id)
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
    }
}

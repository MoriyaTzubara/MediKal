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
using DAL;
using MediKal.Models;

namespace MediKal.Controllers
{
    public class MedicinesController : Controller
    {
        // GET: Medicines
        public ActionResult Index()
        {
            IBL bl = new BL.BL();
            var medicines = bl.GetMedicines().Select(item => new MedicineViewModel(item));
            return View(medicines);
        }

        // GET: Medicines/Details/5
        public ActionResult Details(string id)
        {
            IBL bl = new BL.BL();
            Session["Error"] = "";
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
            Session["Error"] = "Check the image first";
            return View();
        }

        // POST: Medicines/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Medicine medicine,HttpPostedFileBase file)
        {
            try
            {
                IBL bl = new BL.BL();
                if (file == null)
                {
                    bl.AddMedicine(medicine);
                    return RedirectToAction("Index");
                }
                GoogleDriveAPIHelper googleDrive = new GoogleDriveAPIHelper();
                googleDrive.UploadFileOnDrive(file);
                medicine.ImagePath = googleDrive.DownloadGoogleFileByName(file.FileName);
                ImageValidate imageValidate = new ImageValidate();
                bool result = true;
                if (medicine.ImagePath != null)
                {
                    result = imageValidate.Validate(medicine.ImagePath);
                }
                if (result)
                {
                    medicine.ImagePath = $"/GoogleDriveFiles/{file.FileName}";
                    //add image to drive
                    bl.AddMedicine(medicine);
                }
                else
                {
                    Session["Error"] = "This image isn't valid";
                    return View("AddImage", new MedicineViewModel(medicine));
                }
                return RedirectToAction("Index");
            }catch(Exception e) { return View(); }
        }
        // GET: Medicines/Edit/5
        public ActionResult Edit(string id)
        {
            IBL bl = new BL.BL();
            Medicine medicine = bl.GetMedicineById(id);
            if (medicine == null)
            {
                return HttpNotFound();
            }
            Session["Error"] = "";
            return View("Details",new MedicineViewModel(medicine));
        }

        // POST: Medicines/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Medicine medicine, HttpPostedFileBase file)
        {
            try
            {
                IBL bl = new BL.BL();
                GoogleDriveAPIHelper googleDrive = new GoogleDriveAPIHelper();
                googleDrive.UploadFileOnDrive(file);
                medicine.ImagePath = googleDrive.DownloadGoogleFileByName(file.FileName);
                ImageValidate imageValidate = new ImageValidate();
                bool result = true;
                if (medicine.ImagePath != null)
                {
                    result = imageValidate.Validate(medicine.ImagePath);
                }
                if (result)
                {
                    medicine.ImagePath = $"/GoogleDriveFiles/{file.FileName}";
                    //add image to drive
                    bl.UpdateMedicine(medicine,medicine.NDCId);
                }
                else
                {
                    Session["Error"] = "This image isn't valid";
                    return View("Details",new MedicineViewModel(medicine));
                }
                return RedirectToAction("Index");
            }
            catch (Exception e) { return View(); }
        }

        // GET: Medicines/Delete/5
        public ActionResult Delete(string id)
        {
            IBL bl = new BL.BL();
            Medicine medicine = bl.GetMedicineById(id);
            if (medicine == null)
            {
                return HttpNotFound();
            }
            return View(new MedicineViewModel(medicine));
        }
        public ActionResult AddImage(string id)
        {
            Session["Error"] = "";

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

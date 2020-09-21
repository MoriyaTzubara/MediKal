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
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult Index()
        {
            IBL bl = new BL.BL();
            var users = bl.GetUsers().Select(item => new UserViewModel(item));
            return View(users);
        }

        // GET: Users/Details/5
        public ActionResult Details(int id)
        {
            IBL bl = new BL.BL();
            User user = bl.GetUserById(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(new UserViewModel(user));
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserName,Password,Phone,Mail,Birthday,UserType")] User user)
        {
            if (ModelState.IsValid)
            {
                IBL bl = new BL.BL();
                bl.AddUser(user);
                return RedirectToAction("Index");
            }

            return View(new UserViewModel(user));
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int id)
        {
            IBL bl = new BL.BL();
            User user = bl.GetUserById(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(new UserViewModel(user));
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(User user, int Id)
        {
            if (ModelState.IsValid)
            {
                IBL bl = new BL.BL();
                bl.UpdateUser(user,Id);
                return RedirectToAction("Index");
            }
            return View(new UserViewModel(user));
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int id)
        {
            IBL bl = new BL.BL();
            User user = bl.GetUserById(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(new UserViewModel(user));
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            IBL bl = new BL.BL();
            User user = bl.GetUserById(id);
            bl.DeleteUser(id);
            return RedirectToAction("Index");
        }

    }
}

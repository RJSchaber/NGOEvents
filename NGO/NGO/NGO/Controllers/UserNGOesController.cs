﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NGO.Models;

namespace NGO.Controllers
{
    public class UserNGOesController : Controller
    {
        private ngoEntities1 db = new ngoEntities1();

        // GET: UserNGOes
        public ActionResult Index()
        {
            return View(db.UserNGOes.ToList());
        }

        // GET: UserNGOes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserNGO userNGO = db.UserNGOes.Find(id);
            if (userNGO == null)
            {
                return HttpNotFound();
            }
            return View(userNGO);
        }

        // GET: UserNGOes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserNGOes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserID,First_Name,Last_Name,Email,Password,Role")] UserNGO userNGO)
        {
            if (ModelState.IsValid)
            {
                db.UserNGOes.Add(userNGO);
                db.SaveChanges();
                return View("Close");
            }

            return View(userNGO);
        }

        // GET: UserNGOes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserNGO userNGO = db.UserNGOes.Find(id);
            if (userNGO == null)
            {
                return HttpNotFound();
            }
            return View(userNGO);
        }

        // POST: UserNGOes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID,First_Name,Last_Name,Email,Password,Role")] UserNGO userNGO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userNGO).State = EntityState.Modified;
                db.SaveChanges();
                return View("Close");
            }
            return View(userNGO);
        }

        // GET: UserNGOes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserNGO userNGO = db.UserNGOes.Find(id);
            if (userNGO == null)
            {
                return HttpNotFound();
            }
            return View(userNGO);
        }

        // POST: UserNGOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            UserNGO userNGO = db.UserNGOes.Find(id);
            db.UserNGOes.Remove(userNGO);
            db.SaveChanges();
            return View("Close");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

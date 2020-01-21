using System;
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
    public class UserMsController : Controller
    {
        private ngoEntities db = new ngoEntities();

        // GET: UserMs
        public ActionResult Index()
        {
            return View(db.UserMs.ToList());
        }

        // GET: UserMs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserM userM = db.UserMs.Find(id);
            if (userM == null)
            {
                return HttpNotFound();
            }
            return View(userM);
        }

        // GET: UserMs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserMs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "First_Name,Last_Name,Email,Password,Role,UserID")] UserM userM)
        {
            if (ModelState.IsValid)
            {
                db.UserMs.Add(userM);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userM);
        }

        // GET: UserMs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserM userM = db.UserMs.Find(id);
            if (userM == null)
            {
                return HttpNotFound();
            }
            return View(userM);
        }

        // POST: UserMs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "First_Name,Last_Name,Email,Password,Role,UserID")] UserM userM)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userM).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userM);
        }

        // GET: UserMs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserM userM = db.UserMs.Find(id);
            if (userM == null)
            {
                return HttpNotFound();
            }
            return View(userM);
        }

        // POST: UserMs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserM userM = db.UserMs.Find(id);
            db.UserMs.Remove(userM);
            db.SaveChanges();
            return RedirectToAction("Index");
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

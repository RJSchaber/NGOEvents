using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NGO.Models;

namespace NGO.Controllers
{
    public class EventRegistrationsController : Controller
    {
        private ngoEntities1 db = new ngoEntities1();

        // GET: EventRegistrations
        public ActionResult Index()
        {
            var eventRegistrations = db.EventRegistrations.Include(e => e.Event);
            return View(eventRegistrations.ToList());
        }

        // GET: EventRegistrations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventRegistration eventRegistration = db.EventRegistrations.Find(id);
            if (eventRegistration == null)
            {
                return HttpNotFound();
            }
            return View(eventRegistration);
        }

        public ActionResult Create(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Event @event = db.Events.Find(id);

            if (@event == null)
            {
                return HttpNotFound();
            }

            ViewBag.EventName = @event.EventName;
            ViewBag.EventID = @event.EventID;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RegistrationID,FirstName,LastName,EmailAddress,PhoneNumber,Address,AdultTickets,ChildTickets,EventID")] EventRegistration eventRegistration, int? id)
        {
            Event @event = db.Events.Find(id);

            eventRegistration.Event = @event;

            eventRegistration.EventID = @event.EventID;

            if (ModelState.IsValid)
            {
                db.EventRegistrations.Add(eventRegistration);
                db.SaveChanges();
                return RedirectToAction("EventUserView", "Events" );
            }

            //ViewBag.EventID = new SelectList(db.Events, "EventID", "EventName", eventRegistration.EventID);
            return View(eventRegistration);
        }

        // GET: EventRegistrations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventRegistration eventRegistration = db.EventRegistrations.Find(id);
            if (eventRegistration == null)
            {
                return HttpNotFound();
            }
            ViewBag.EventID = new SelectList(db.Events, "EventID", "EventName", eventRegistration.EventID);
            return View(eventRegistration);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RegistrationID,FirstName,LastName,EmailAddress,PhoneNumber,Address,AdultTickets,ChildTickets,EventID")] EventRegistration eventRegistration)
        {

            if (ModelState.IsValid)
            {
                db.Entry(eventRegistration).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EventID = new SelectList(db.Events, "EventID", "EventName", eventRegistration.EventID);
            return View(eventRegistration);
        }

        // GET: EventRegistrations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventRegistration eventRegistration = db.EventRegistrations.Find(id);
            if (eventRegistration == null)
            {
                return HttpNotFound();
            }
            return View(eventRegistration);
        }

        // POST: EventRegistrations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EventRegistration eventRegistration = db.EventRegistrations.Find(id);
            db.EventRegistrations.Remove(eventRegistration);
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

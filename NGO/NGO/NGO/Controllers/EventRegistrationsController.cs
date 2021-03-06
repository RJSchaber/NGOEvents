﻿using System;
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

        public ActionResult Details(EventRegistration eventRegistration)
        {
            Event @event = db.Events.Find(eventRegistration.EventID);
            decimal adultTickets = @event.AdultTicket;
            decimal childTickets = @event.ChildTicket;
            decimal adultCost = adultTickets * eventRegistration.AdultTickets;
            decimal childCost = childTickets * eventRegistration.ChildTickets;
            decimal totalCost = adultCost + childCost;
            ViewBag.EventName = @event.EventName;

            eventRegistration.ChildCost = childCost;
            eventRegistration.AdultCost = adultCost;
            eventRegistration.TotalCost = totalCost;
            this.Session["EventRegistration"] = eventRegistration;
            return View(eventRegistration);
        }

        [HttpPost]
        public ActionResult Details()
        {
            var eventRegistration = this.Session["EventRegistration"] as EventRegistration;
            db.EventRegistrations.Add(eventRegistration);
            db.SaveChanges();
            return RedirectToAction("Confirmed", "EventRegistrations", eventRegistration);
        }

        public ActionResult DetailsAdmin(EventRegistration eventRegistration)
        {
            Event @event = db.Events.Find(eventRegistration.EventID);
            decimal adultTickets = @event.AdultTicket;
            decimal childTickets = @event.ChildTicket;
            decimal adultCost = adultTickets * eventRegistration.AdultTickets;
            decimal childCost = childTickets * eventRegistration.ChildTickets;
            decimal totalCost = adultCost + childCost;
            ViewBag.EventName = @event.EventName;

            eventRegistration.ChildCost = childCost;
            eventRegistration.AdultCost = adultCost;
            eventRegistration.TotalCost = totalCost;
            this.Session["EventRegistration"] = eventRegistration;
            return View(eventRegistration);
        }

        [HttpPost]
        public ActionResult DetailsAdmin()
        {
            var eventRegistration = this.Session["EventRegistration"] as EventRegistration;
            db.EventRegistrations.Add(eventRegistration);
            db.SaveChanges();
            return RedirectToAction("ConfirmedAdmin", "EventRegistrations", eventRegistration);
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
            ViewBag.ImagePath = @event.EventImage;

            return View();
        }
        public ActionResult CreateAdmin(int? id)
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
            ViewBag.ImagePath = @event.EventImage;

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
                return RedirectToAction("Details", "EventRegistrations", eventRegistration );
            }

            return View(eventRegistration);
        }
        public ActionResult CreateAdmin([Bind(Include = "RegistrationID,FirstName,LastName,EmailAddress,PhoneNumber,Address,AdultTickets,ChildTickets,EventID")] EventRegistration eventRegistration, int? id)
        {
            Event @event = db.Events.Find(id);
            eventRegistration.Event = @event;
            eventRegistration.EventID = @event.EventID;

            if (ModelState.IsValid)
            {
                return RedirectToAction("DetailsAdmin", "EventRegistrations", eventRegistration);
            }

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

        public ActionResult Confirmed(EventRegistration eventRegistration)
        {
            return View(eventRegistration);
        }
        public ActionResult ConfirmedAdmin(EventRegistration eventRegistration)
        {
            return View(eventRegistration);
        }

    }
}

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
using System.Web.Mvc.Ajax;


namespace NGO.Controllers
{
    public class EventsController : Controller
    {

        private ngoEntities1 db = new ngoEntities1();

        // GET: Events
        public ActionResult Index()
        {
            return View(db.Events.ToList());
        }

        // GET: Events/Details/5
        public ActionResult Details(int? id)
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
            return View(@event);
        }

        // GET: Events/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EventName,EventDescription,EventCategory,EventStartDate,EventEndDate,EventStartTime,EventEndTime,Location,RegOpen,EventImage,AdultTicket,ChildTicket,ImageFile")]Event @event)
        {
            string fileName = Path.GetFileNameWithoutExtension(@event.ImageFile.FileName);
            string extension = Path.GetExtension(@event.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            @event.EventImage = "~/EventImages/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/EventImages/"), fileName);
            @event.ImageFile.SaveAs(fileName);

            @event.EventStartTime = DateTime.Parse(@event.EventStartTime).ToString("hh:mm tt");
            @event.EventEndTime = DateTime.Parse(@event.EventEndTime).ToString("hh:mm tt");

            if (ModelState.IsValid)
            {
                db.Events.Add(@event);
                db.SaveChanges();
                return View("Close");
            }

            return View(@event);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
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
            return PartialView(@event);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EventID,EventName,EventDescription,EventCategory,EventStartDate,EventEndDate,EventStartTime,EventEndTime,Location,RegOpen,EventImage,AdultTicket,ChildTicket,ImageFile")] Event @event)
        {
            string fileName = Path.GetFileNameWithoutExtension(@event.ImageFile.FileName);
            string extension = Path.GetExtension(@event.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            @event.EventImage = "~/EventImages/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/EventImages/"), fileName);
            @event.ImageFile.SaveAs(fileName);

            @event.EventStartTime = DateTime.Parse(@event.EventStartTime).ToString("hh:mm tt");
            @event.EventEndTime = DateTime.Parse(@event.EventEndTime).ToString("hh:mm tt");

            if (ModelState.IsValid)
            {
                db.Entry(@event).State = EntityState.Modified;
                db.SaveChanges();
                return View("Close");
            }
            return View(@event);
        }

        // GET: Events/Delete/5
        public ActionResult Delete(int? id)
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
            return View(@event);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Event @event = db.Events.Find(id);
            db.Events.Remove(@event);
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

        public ActionResult EventUserView()
        {
            return View(db.Events.ToList());
        }

    }
}

using NGOassignment.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace NGOassignment.Controllers
{
    public class UserController : Controller
    {
        private ngoEntities db = new ngoEntities();

        // GET: User
        public ActionResult Index()
        {
            return View(db.UserNGOes.ToList());
        }

        // GET: User/Details/5
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

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
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
                return RedirectToAction("Index");
            }

            return View(userNGO);
        }

        // GET: User/Edit/5
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

        // POST: User/Edit/5
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
                return RedirectToAction("Index");
            }
            return View(userNGO);
        }

        // GET: User/Delete/5
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

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            UserNGO userNGO = db.UserNGOes.Find(id);
            db.UserNGOes.Remove(userNGO);
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

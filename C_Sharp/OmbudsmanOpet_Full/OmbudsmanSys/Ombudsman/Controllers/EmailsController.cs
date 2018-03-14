using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Ombudsman.Contexts;
using Ombudsman.Models;

namespace Ombudsman.Controllers
{
    public class EmailsController : Controller
    {
        private EFContext db = new EFContext();

        // GET: Emails
        public ActionResult Index()
        {
            var emails = db.Emails.Include(e => e.Protester).Include(e => e.User);
            return View(emails.ToList());
        }

        // GET: Emails/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Email email = db.Emails.Find(id);
            if (email == null)
            {
                return HttpNotFound();
            }
            return View(email);
        }

        // GET: Emails/Create
        public ActionResult Create()
        {
            ViewBag.ProtesterId = new SelectList(db.Protesters, "ProtesterId", "ProtesterName");
            ViewBag.UserId = new SelectList(db.Users, "UserId", "UserCpf");
            return View();
        }

        // POST: Emails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmailId,EmailDescription,ProtesterId,UserId")] Email email)
        {
            if (ModelState.IsValid)
            {
                db.Emails.Add(email);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProtesterId = new SelectList(db.Protesters, "ProtesterId", "ProtesterName", email.ProtesterId);
            ViewBag.UserId = new SelectList(db.Users, "UserId", "UserCpf", email.UserId);
            return View(email);
        }

        // GET: Emails/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Email email = db.Emails.Find(id);
            if (email == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProtesterId = new SelectList(db.Protesters, "ProtesterId", "ProtesterName", email.ProtesterId);
            ViewBag.UserId = new SelectList(db.Users, "UserId", "UserCpf", email.UserId);
            return View(email);
        }

        // POST: Emails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmailId,EmailDescription,ProtesterId,UserId")] Email email)
        {
            if (ModelState.IsValid)
            {
                db.Entry(email).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProtesterId = new SelectList(db.Protesters, "ProtesterId", "ProtesterName", email.ProtesterId);
            ViewBag.UserId = new SelectList(db.Users, "UserId", "UserCpf", email.UserId);
            return View(email);
        }

        // GET: Emails/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Email email = db.Emails.Find(id);
            if (email == null)
            {
                return HttpNotFound();
            }
            return View(email);
        }

        // POST: Emails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Email email = db.Emails.Find(id);
            db.Emails.Remove(email);
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

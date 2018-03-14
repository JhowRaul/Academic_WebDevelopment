using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OmbudsmanOpet.Contexts;
using OmbudsmanOpet.Models;

namespace OmbudsmanOpet.Controllers
{
    public class AuthorizedEmailsController : Controller
    {
        private EFContext db = new EFContext();

        // GET: AuthorizedEmails
        public ActionResult Index()
        {
            var authorizedEmails = db.AuthorizedEmails.Include(a => a.Manifestation);
            return View(authorizedEmails.ToList());
        }

        // GET: AuthorizedEmails/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AuthorizedEmail authorizedEmail = db.AuthorizedEmails.Find(id);
            if (authorizedEmail == null)
            {
                return HttpNotFound();
            }
            return View(authorizedEmail);
        }

        // GET: AuthorizedEmails/Create/id
        public ActionResult Create(long id)
        {
            ViewData["ManifestationId"] = id; 
            //ViewBag.ManifestationId = new SelectList(db.Manifestations, "ManifestationId", "ManifestationId");
            return View();
        }

        // POST: AuthorizedEmails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AuthorizedEmailId,Description,ManifestationId")] AuthorizedEmail authorizedEmail)
        {
            if (ModelState.IsValid)
            {
                db.AuthorizedEmails.Add(authorizedEmail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ManifestationId = new SelectList(db.Manifestations, "ManifestationId", "ManifestationId", authorizedEmail.ManifestationId);
            return View(authorizedEmail);
        }

        // GET: AuthorizedEmails/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AuthorizedEmail authorizedEmail = db.AuthorizedEmails.Find(id);
            if (authorizedEmail == null)
            {
                return HttpNotFound();
            }
            ViewBag.ManifestationId = new SelectList(db.Manifestations, "ManifestationId", "ManifestationId", authorizedEmail.ManifestationId);
            return View(authorizedEmail);
        }

        // POST: AuthorizedEmails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AuthorizedEmailId,Description,ManifestationId")] AuthorizedEmail authorizedEmail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(authorizedEmail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ManifestationId = new SelectList(db.Manifestations, "ManifestationId", "ManifestationId", authorizedEmail.ManifestationId);
            return View(authorizedEmail);
        }

        // GET: AuthorizedEmails/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AuthorizedEmail authorizedEmail = db.AuthorizedEmails.Find(id);
            if (authorizedEmail == null)
            {
                return HttpNotFound();
            }
            return View(authorizedEmail);
        }

        // POST: AuthorizedEmails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            AuthorizedEmail authorizedEmail = db.AuthorizedEmails.Find(id);
            db.AuthorizedEmails.Remove(authorizedEmail);
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

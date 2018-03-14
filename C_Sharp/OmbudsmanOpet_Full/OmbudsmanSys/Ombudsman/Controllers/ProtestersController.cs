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
    public class ProtestersController : Controller
    {
        private EFContext db = new EFContext();

        // GET: Protesters
        public ActionResult Index()
        {
            return View(db.Protesters.ToList());
        }

        // GET: Protesters/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Protester protester = db.Protesters.Find(id);
            if (protester == null)
            {
                return HttpNotFound();
            }
            return View(protester);
        }

        // GET: Protesters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Protesters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProtesterId,ProtesterCpf,ProtesterName,ProtesterGenre")] Protester protester)
        {
            if (ModelState.IsValid)
            {
                db.Protesters.Add(protester);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(protester);
        }

        // GET: Protesters/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Protester protester = db.Protesters.Find(id);
            if (protester == null)
            {
                return HttpNotFound();
            }
            return View(protester);
        }

        // POST: Protesters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProtesterId,ProtesterCpf,ProtesterName,ProtesterGenre")] Protester protester)
        {
            if (ModelState.IsValid)
            {
                db.Entry(protester).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(protester);
        }

        // GET: Protesters/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Protester protester = db.Protesters.Find(id);
            if (protester == null)
            {
                return HttpNotFound();
            }
            return View(protester);
        }

        // POST: Protesters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Protester protester = db.Protesters.Find(id);
            db.Protesters.Remove(protester);
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

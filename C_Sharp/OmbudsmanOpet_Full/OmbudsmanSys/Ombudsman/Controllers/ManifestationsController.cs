using Ombudsman.Contexts;
using Ombudsman.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Ombudsman.Controllers
{
    public class ManifestationsController : Controller
    {
        private EFContext context = new EFContext();

        // GET: Manifestations
        public ActionResult Index()
        {
            return View(context.Manifestations.OrderBy(
                c => c.ManifestationId));
        }

        #region Region Details

        // GET: Manifestations/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new
                    HttpStatusCodeResult(
                    HttpStatusCode.BadRequest);
            }

            Manifestation manifestation = context.Manifestations
                .Where(f => f.ManifestationId == id)
                .Include("Messages.Manifestation").First();
            if (manifestation == null)
            {
                return HttpNotFound();
            }

            return View(manifestation);
        }

        #endregion

        #region Region Create

        // GET: Manifestations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Manifestations/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Manifestation manifestation)
        {
            context.Manifestations.Add(manifestation);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        #endregion

        #region Region Edit

        // GET: Manifestations/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new
                    HttpStatusCodeResult(
                    HttpStatusCode.BadRequest);
            }

            Manifestation manifestation = context.Manifestations.Find(id);
            if (manifestation == null)
            {
                return HttpNotFound();
            }

            return View(manifestation);
        }

        // POST: Manifestations/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Manifestation manifestation)
        {
            if (ModelState.IsValid)
            {
                if (manifestation.Status == "Closed")
                    manifestation.ClosingDate = DateTime.Now;
                context.Entry(manifestation).State =
                    EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(manifestation);
        }

        #endregion

        #region Region Delete
        // GET: Manifestations/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new
                    HttpStatusCodeResult(
                    HttpStatusCode.BadRequest);
            }

            Manifestation manifestation = context.Manifestations.Find(id);
            if (manifestation == null)
            {
                return HttpNotFound();
            }

            return View(manifestation);
        }

        // POST: Manifestations/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection collection)
        {
            Manifestation manifestation = context.Manifestations.Find(id);
            context.Manifestations.Remove(manifestation);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        #endregion

    }
}
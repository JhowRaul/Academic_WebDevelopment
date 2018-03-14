using OmbudsmanOpet.Contexts;
using OmbudsmanOpet.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace OmbudsmanOpet.Controllers
{
    public class ManifestationsController : Controller
    {
        private EFContext context = new EFContext();
        // GET: Manifestations
        public ActionResult Index()
        {
            return View(context.Manifestations.OrderBy(
                c => c.Status));
        }
        
        private ActionResult View(Func<ActionResult> home)
        {
            throw new NotImplementedException();
        }

        #region CREATE MANIFESTATION

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Manifestation manifestation)
        {
            context.Manifestations.Add(manifestation);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        #endregion

        #region DETAILS MANIFESTATION

        // GET: Manifestations/Details/ id
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new
                    HttpStatusCodeResult(
                    HttpStatusCode.BadRequest);
            }

            Manifestation manifestation = context
                .Manifestations
                .Include(m => m.AuthorizedEmails)
                .FirstOrDefault(m => m.ManifestationId == id.Value);
            if (manifestation == null)
            {
                return HttpNotFound();
            }

            return View(manifestation);
        }

        #endregion

        #region EDIT MANIFESTATION

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

        [HttpPost]
        [ValidateAntiForgeryToken]

        // POST: Manifestations/Edit/ id
        public ActionResult Edit(Manifestation manifestation)
        {
            if (ModelState.IsValid)
            {
                if (manifestation.Status == "cl")
                    manifestation.ClosingDate = DateTime.Now;
                context.Entry(manifestation).State =
                    EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(manifestation);
        }

        #endregion

        #region DELETE MANIFESTATION

        // GET: Manifestations/Delete/ id
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

        // POST: Manifestation/Delete/ id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            Manifestation manifestation = context.Manifestations.Find(id);
            context.Manifestations.Remove(manifestation);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        #endregion

    }
}
using Ombudsman.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;
using Ombudsman.Models;

namespace Ombudsman.Controllers
{
    public class MessagesController : Controller
    {
        private EFContext context = new EFContext();

        // GET: Messages
        public ActionResult Index()
        {
            var messages = context.Messages.Include(c => c.Manifestation).
                OrderBy(n => n.DateMessage);
            return View(messages);
        }

        #region Region Details

        // GET: Messages/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                           HttpStatusCode.BadRequest);
            }

            Message message = context.Messages.Where(p => p.MessageId == id).
                Include(m => m.Manifestation).First();
            if (message == null)
            {
                return HttpNotFound();
            }

            return View(message);
        }

        #endregion

        #region Region Create

        // GET: Messages/Create
        public ActionResult Create()
        {
            ViewBag.ManifestationId = new SelectList(context.Manifestations,
                "ManifestationId", "SubjectMatter");
            return View();
        }

        // POST: Messages/Create
        [HttpPost]
        public ActionResult Create(Message message)
        {
            try
            {
                context.Messages.Add(message);
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View(message);
            }
        }

        #endregion

        #region Region Edit

        // GET: Messages/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                           HttpStatusCode.BadRequest);
            }

            Message message = context.Messages.Find(id);
            if (message == null)
            {
                return HttpNotFound();
            }
            ViewBag.ManifestationId = new SelectList(context.Manifestations,
                "ManifestationId", "SubjectMatter", message.ManifestationId);

            return View(message);
        }

        // POST: Messages/Edit/5
        [HttpPost]
        public ActionResult Edit(Message message)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    context.Entry(message).State = EntityState.Modified;
                    context.SaveChanges();

                    return RedirectToAction("Index");
                }
                return View(message);
            }
            catch
            {
                return View(message);
            }
        }

        #endregion

        #region Region Delete

        // GET: Messages/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                           HttpStatusCode.BadRequest);
            }

            Message message = context.Messages.Where(p => p.MessageId ==
                id).Include(c => c.Manifestation).First();
            if (message == null)
            {
                return HttpNotFound();
            }

            return View(message);
        }

        // POST: Messages/Delete/5
        [HttpPost]
        public ActionResult Delete(long id)
        {
            try
            {
                Message message = context.Messages.Find(id);
                context.Messages.Remove(message);
                context.SaveChanges();
                TempData["Message"] = "Message " + message.Content.ToUpper()
                    + " was removed";

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        #endregion

    }
}
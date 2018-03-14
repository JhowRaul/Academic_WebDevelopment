using JhowRaul.Contexts;
using JhowRaul.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace JhowRaul.Controllers
{
    public class SuppliesController : Controller
    {
        private EFContext context = new EFContext();

        // GET: Supplies
        public ActionResult Index()
        {
            return View(context.Supplies.OrderBy(
                c => c.Name));
        }


        #region Create

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Supply supply)
        {
            context.Supplies.Add(supply);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        #endregion

        #region Edit

        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new
                    HttpStatusCodeResult(
                    HttpStatusCode.BadRequest);
            }

            Supply supply = context.Supplies.Find(id);
            if (supply == null)
            {
                return HttpNotFound();
            }

            return View(supply);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Supply supply)
        {
            if (ModelState.IsValid)
            {
                context.Entry(supply).State =
                    EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(supply);
        }

        #endregion

        #region Details

        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new
                    HttpStatusCodeResult(
                    HttpStatusCode.BadRequest);
            }

            Supply supply = context.Supplies.Find(id);
            if (supply == null)
            {
                return HttpNotFound();
            }
            return View(supply);

        }

        #endregion

        #region Remove

        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new
                    HttpStatusCodeResult(
                    HttpStatusCode.BadRequest);
            }

            Supply supply = context.Supplies.Find(id);
            if (supply == null)
            {
                return HttpNotFound();
            }

            return View(supply);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            Supply supply = context.Supplies.Find(id);
            context.Supplies.Remove(supply);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        #endregion

    }
}
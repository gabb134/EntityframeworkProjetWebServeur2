using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Marrero_projet01.Context;
using Marrero_projet01.Models;

namespace Marrero_projet01.Controllers
{
    public class Entreprise_EntrepriseController : Controller
    {
        private CustomerManagementContext db = new CustomerManagementContext();

        // GET: Entreprise_Entreprise
        public ActionResult Index()
        {
            return View(db.Entreprises.ToList());
        }

        // GET: Entreprise_Entreprise/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Entreprise_Entreprise entreprise_Entreprise = db.Entreprises.Find(id);
            if (entreprise_Entreprise == null)
            {
                return HttpNotFound();
            }
            return View(entreprise_Entreprise);
        }

        // GET: Entreprise_Entreprise/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Entreprise_Entreprise/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EntrepriseID,EntrepriseName,EntrepriseNote,DateInscrit,DateMod")] Entreprise_Entreprise entreprise_Entreprise)
        {
            if (ModelState.IsValid)
            {
                entreprise_Entreprise.DateInscrit = DateTime.Now;
                entreprise_Entreprise.DateMod = DateTime.Now;
                db.Entreprises.Add(entreprise_Entreprise);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(entreprise_Entreprise);
        }

        // GET: Entreprise_Entreprise/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Entreprise_Entreprise entreprise_Entreprise = db.Entreprises.Find(id);
            if (entreprise_Entreprise == null)
            {
                return HttpNotFound();
            }
            return View(entreprise_Entreprise);
        }

        // POST: Entreprise_Entreprise/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EntrepriseID,EntrepriseName,EntrepriseNote,DateInscrit,DateMod")] Entreprise_Entreprise entreprise_Entreprise)
        {
            if (ModelState.IsValid)
            {
                entreprise_Entreprise.DateMod = DateTime.Now;
                db.Entry(entreprise_Entreprise).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(entreprise_Entreprise);
        }

        // GET: Entreprise_Entreprise/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Entreprise_Entreprise entreprise_Entreprise = db.Entreprises.Find(id);
            if (entreprise_Entreprise == null)
            {
                return HttpNotFound();
            }
            return View(entreprise_Entreprise);
        }

        // POST: Entreprise_Entreprise/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Entreprise_Entreprise entreprise_Entreprise = db.Entreprises.Find(id);
            db.Entreprises.Remove(entreprise_Entreprise);
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

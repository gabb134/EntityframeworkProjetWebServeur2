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
    public class Employee_PhoneNumberTypeController : Controller
    {
        private CustomerManagementContext db = new CustomerManagementContext();

        // GET: Employee_PhoneNumberType
        public ActionResult Index()
        {
            return View(db.NumeroTypes.ToList());
        }

        // GET: Employee_PhoneNumberType/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee_PhoneNumberType employee_PhoneNumberType = db.NumeroTypes.Find(id);
            if (employee_PhoneNumberType == null)
            {
                return HttpNotFound();
            }
            return View(employee_PhoneNumberType);
        }

        // GET: Employee_PhoneNumberType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee_PhoneNumberType/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PhoneNumberTypeID,PhoneNumbertype,ModifiedDate")] Employee_PhoneNumberType employee_PhoneNumberType)
        {
            if (ModelState.IsValid)
            {
                employee_PhoneNumberType.ModifiedDate = DateTime.Now;
                db.NumeroTypes.Add(employee_PhoneNumberType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employee_PhoneNumberType);
        }

        // GET: Employee_PhoneNumberType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee_PhoneNumberType employee_PhoneNumberType = db.NumeroTypes.Find(id);
            if (employee_PhoneNumberType == null)
            {
                return HttpNotFound();
            }
            return View(employee_PhoneNumberType);
        }

        // POST: Employee_PhoneNumberType/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PhoneNumberTypeID,PhoneNumbertype,ModifiedDate")] Employee_PhoneNumberType employee_PhoneNumberType)
        {
            if (ModelState.IsValid)
            {
                employee_PhoneNumberType.ModifiedDate = DateTime.Now;
                db.Entry(employee_PhoneNumberType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee_PhoneNumberType);
        }

        // GET: Employee_PhoneNumberType/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee_PhoneNumberType employee_PhoneNumberType = db.NumeroTypes.Find(id);
            if (employee_PhoneNumberType == null)
            {
                return HttpNotFound();
            }
            return View(employee_PhoneNumberType);
        }

        // POST: Employee_PhoneNumberType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee_PhoneNumberType employee_PhoneNumberType = db.NumeroTypes.Find(id);
            db.NumeroTypes.Remove(employee_PhoneNumberType);
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

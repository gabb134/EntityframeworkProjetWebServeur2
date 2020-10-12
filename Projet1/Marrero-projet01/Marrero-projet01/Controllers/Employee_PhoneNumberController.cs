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
    public class Employee_PhoneNumberController : Controller
    {
        private CustomerManagementContext db = new CustomerManagementContext();

        // GET: Employee_PhoneNumber
        public ActionResult Index()
        {
            var employesNumeros = db.EmployesNumeros.Include(e => e.Employee).Include(e => e.EmployeePhoneType);
            return View(employesNumeros.ToList());
        }

        // GET: Employee_PhoneNumber/Details/5
        public ActionResult Details(int? id, int? id2)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee_PhoneNumber employee_PhoneNumber = db.EmployesNumeros.Find(id2, id);
            if (employee_PhoneNumber == null)
            {
                return HttpNotFound();
            }
            return View(employee_PhoneNumber);
        }

        // GET: Employee_PhoneNumber/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeID = new SelectList(db.Employes, "EmployeeID", "FirstName");
            ViewBag.PhoneNumberTypeID = new SelectList(db.NumeroTypes, "PhoneNumberTypeID", "PhoneNumbertype");
            return View();
        }

        // POST: Employee_PhoneNumber/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeID,PhoneNumberID,PhoneNumber,ModifiedDate,PhoneNumberTypeID")] Employee_PhoneNumber employee_PhoneNumber)
        {
            if (ModelState.IsValid) //demander au prof pour cette situation ou il faut que le champ PhoneNumberID de la table Employee_PhoneNumber soir le meme que le champ PhoneNumberID de la table Employee_PhoneNumberType
            {
                employee_PhoneNumber.ModifiedDate = DateTime.Now;
              
                var typesNumeros = from b in db.NumeroTypes
                            where b.PhoneNumberTypeID == employee_PhoneNumber.PhoneNumberTypeID
                            select b;

                foreach (Employee_PhoneNumberType type in typesNumeros)
                {
                    employee_PhoneNumber.PhoneNumberTypeID = type.PhoneNumberTypeID;
                }
               //employee_PhoneNumber.PhoneNumberID = 

               // employee_PhoneNumber.PhoneNumberID = query.FirstOrDefault<Employee_PhoneNumberType>();


                db.EmployesNumeros.Add(employee_PhoneNumber);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeID = new SelectList(db.Employes, "EmployeeID", "FirstName", employee_PhoneNumber.EmployeeID);
            ViewBag.PhoneNumberTypeID = new SelectList(db.NumeroTypes, "PhoneNumberTypeID", "PhoneNumbertype", employee_PhoneNumber.PhoneNumberTypeID);
            return View(employee_PhoneNumber);
        }

        // GET: Employee_PhoneNumber/Edit/5
        public ActionResult Edit(int? id, int? id2)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee_PhoneNumber employee_PhoneNumber = db.EmployesNumeros.Find(id2, id);
            if (employee_PhoneNumber == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeID = new SelectList(db.Employes, "EmployeeID", "FirstName", employee_PhoneNumber.EmployeeID);
            ViewBag.PhoneNumberTypeID = new SelectList(db.NumeroTypes, "PhoneNumberTypeID", "PhoneNumbertype", employee_PhoneNumber.PhoneNumberTypeID);
            return View(employee_PhoneNumber);
        }

        // POST: Employee_PhoneNumber/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeID,PhoneNumberID,PhoneNumber,ModifiedDate,PhoneNumberTypeID")] Employee_PhoneNumber employee_PhoneNumber)
        {
            if (ModelState.IsValid)
            {
                employee_PhoneNumber.ModifiedDate = DateTime.Now;
                db.Entry(employee_PhoneNumber).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeID = new SelectList(db.Employes, "EmployeeID", "FirstName", employee_PhoneNumber.EmployeeID);
            ViewBag.PhoneNumberTypeID = new SelectList(db.NumeroTypes, "PhoneNumberTypeID", "PhoneNumbertype", employee_PhoneNumber.PhoneNumberTypeID);
            return View(employee_PhoneNumber);
        }

        // GET: Employee_PhoneNumber/Delete/5
        public ActionResult Delete(int? id, int? id2)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee_PhoneNumber employee_PhoneNumber = db.EmployesNumeros.Find(id2, id);
            if (employee_PhoneNumber == null)
            {
                return HttpNotFound();
            }
            return View(employee_PhoneNumber);
        }

        // POST: Employee_PhoneNumber/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, int id2)
        {
            Employee_PhoneNumber employee_PhoneNumber = db.EmployesNumeros.Find(id2, id);
            db.EmployesNumeros.Remove(employee_PhoneNumber);
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

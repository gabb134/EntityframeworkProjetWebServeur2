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
    public class Employee_EmployeeController : Controller
    {
        private CustomerManagementContext db = new CustomerManagementContext();

        // GET: Employee_Employee
        public ActionResult Index()
        {
            var employes = db.Employes.Include(e => e.Entreprise);
            return View(employes.ToList());
        }

        // GET: Employee_Employee/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee_Employee employee_Employee = db.Employes.Find(id);
            if (employee_Employee == null)
            {
                return HttpNotFound();
            }
            return View(employee_Employee);
        }

        // GET: Employee_Employee/Create
        public ActionResult Create()
        {
            ViewBag.EntrepriseID = new SelectList(db.Entreprises, "EntrepriseID", "EntrepriseName");
            return View();
        }

        // POST: Employee_Employee/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeID,FirstName,MiddleName,LastName,Gender,EmailAddress,Titre,Departement,ModifiedDate,EntrepriseID")] Employee_Employee employee_Employee)
        {
            if (ModelState.IsValid)
            {
                employee_Employee.ModifiedDate = DateTime.Now;
                db.Employes.Add(employee_Employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EntrepriseID = new SelectList(db.Entreprises, "EntrepriseID", "EntrepriseName", employee_Employee.EntrepriseID);
            return View(employee_Employee);
        }

        // GET: Employee_Employee/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee_Employee employee_Employee = db.Employes.Find(id);
            if (employee_Employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.EntrepriseID = new SelectList(db.Entreprises, "EntrepriseID", "EntrepriseName", employee_Employee.EntrepriseID);
            return View(employee_Employee);
        }

        // POST: Employee_Employee/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeID,FirstName,MiddleName,LastName,Gender,EmailAddress,Titre,Departement,ModifiedDate,EntrepriseID")] Employee_Employee employee_Employee)
        {
            if (ModelState.IsValid)
            {
                employee_Employee.ModifiedDate = DateTime.Now;
                db.Entry(employee_Employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EntrepriseID = new SelectList(db.Entreprises, "EntrepriseID", "EntrepriseName", employee_Employee.EntrepriseID);
            return View(employee_Employee);
        }

        // GET: Employee_Employee/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee_Employee employee_Employee = db.Employes.Find(id);
            if (employee_Employee == null)
            {
                return HttpNotFound();
            }
            return View(employee_Employee);
        }

        // POST: Employee_Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee_Employee employee_Employee = db.Employes.Find(id);
            db.Employes.Remove(employee_Employee);
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

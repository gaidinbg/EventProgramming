using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EmployeeManagement.Models;
using EmployeeManagement.Data_Access;

namespace EmployeeManagement.Controllers
{
    public class EmployeeController : Controller
    {
        private EmployeesManagementDBContext db = new EmployeesManagementDBContext();

        // GET: /Employee/
        public ActionResult Index()
        {
            return View(db.EmployeeViewModels.ToList());
        }

        // GET: /Employee/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeViewModel employeeviewmodel = db.EmployeeViewModels.Find(id);
            if (employeeviewmodel == null)
            {
                return HttpNotFound();
            }
            return View(employeeviewmodel);
        }

        // GET: /Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Employee/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,FirstName,LastName,Phone,CreatedAt,UpdatedAt")] EmployeeViewModel employeeviewmodel)
        {
            if (ModelState.IsValid)
            {
                db.EmployeeViewModels.Add(employeeviewmodel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employeeviewmodel);
        }

        // GET: /Employee/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeViewModel employeeviewmodel = db.EmployeeViewModels.Find(id);
            if (employeeviewmodel == null)
            {
                return HttpNotFound();
            }
            return View(employeeviewmodel);
        }

        // POST: /Employee/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,FirstName,LastName,Phone,CreatedAt,UpdatedAt")] EmployeeViewModel employeeviewmodel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeeviewmodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employeeviewmodel);
        }

        // GET: /Employee/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeViewModel employeeviewmodel = db.EmployeeViewModels.Find(id);
            if (employeeviewmodel == null)
            {
                return HttpNotFound();
            }
            return View(employeeviewmodel);
        }

        // POST: /Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmployeeViewModel employeeviewmodel = db.EmployeeViewModels.Find(id);
            db.EmployeeViewModels.Remove(employeeviewmodel);
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

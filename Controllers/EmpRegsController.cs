using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EmployeeManagement.Models;

namespace EmployeeManagement.Controllers
{
    public class EmpRegsController : Controller
    {
        private employeeDBEntities db = new employeeDBEntities();

        // GET: EmpRegs
        public ActionResult Index()
        {
            return View(db.EmpRegs.ToList());
        }

        // GET: EmpRegs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpReg empReg = db.EmpRegs.Find(id);
            if (empReg == null)
            {
                return HttpNotFound();
            }
            return View(empReg);
        }

        // GET: EmpRegs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmpRegs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EMPID,FIRST_NAME,LAST_NAME,AGE,DESIGNATION,SALARY")] EmpReg empReg)
        {
            if (ModelState.IsValid)
            {
                db.EmpRegs.Add(empReg);
                db.SaveChanges();
                TempData["AlertMessage"] = "Registration Succesful...";
                return RedirectToAction("Index");
            }

            return View(empReg);
        }

        // GET: EmpRegs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpReg empReg = db.EmpRegs.Find(id);
            if (empReg == null)
            {
                return HttpNotFound();
            }
            return View(empReg);
        }

        // POST: EmpRegs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EMPID,FIRST_NAME,LAST_NAME,AGE,DESIGNATION,SALARY")] EmpReg empReg)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empReg).State = EntityState.Modified;
                db.SaveChanges();
                TempData["AlertMessage"] = "Updated Succesfully...";
                return RedirectToAction("Index");
            }
            return View(empReg);
        }

        // GET: EmpRegs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpReg empReg = db.EmpRegs.Find(id);
            if (empReg == null)
            {
                return HttpNotFound();
            }
            return View(empReg);
        }

        // POST: EmpRegs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmpReg empReg = db.EmpRegs.Find(id);
            db.EmpRegs.Remove(empReg);
            db.SaveChanges();
            TempData["AlertMessage"] = "Deleted Succesfully...";
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

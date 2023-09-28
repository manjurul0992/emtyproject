using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using emtyproject.Models;
using emtyproject.Models.ViewModels;

namespace emtyproject.Controllers
{
    public class HomeController : Controller
    {
        private readonly EmployeeDbContext db = new EmployeeDbContext();
        // GET: Home
        public ActionResult Index()
        {
            var data = db.Employees
                .Select(e => new EmployeeViewModel
                {
                    EmployeeId = e.EmployeeId,
                    EmployeeName = e.EmployeeName,
                    JoinDate = e.JoinDate,
                    Grade = e.Grade
                }).ToList();
            return View(data);
        }
        public ActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Insert(Employee emp)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(emp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Insert",emp);
        }
        public ActionResult Edit(int id)
        {
            return View(db.Employees.First(x=>x.EmployeeId==id));
        }
        [HttpPost]
        public ActionResult Edit(Employee emp)
        {
            if (ModelState.IsValid)
            {
                db.Entry(emp).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(emp);
        }

        public ActionResult Delete(int id)
        {
            // Find the employee by ID
            var employeeToDelete = db.Employees.Find(id);

            if (employeeToDelete == null)
            {
                // Handle the case where the employee with the given ID doesn't exist.
                return HttpNotFound();
            }

            return View(employeeToDelete);
        }

        // POST: Home/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            // Find the employee by ID
            var employeeToDelete = db.Employees.Find(id);

            if (employeeToDelete == null)
            {
                // Handle the case where the employee with the given ID doesn't exist.
                return HttpNotFound();
            }

            // Delete the employee
            db.Employees.Remove(employeeToDelete);

            // Save changes to the database
            db.SaveChanges();

            // Redirect to a page after successful deletion
            return RedirectToAction("Index");
        }

    }
    
}
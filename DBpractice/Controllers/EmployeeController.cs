using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DBpractice.Models;

namespace DBpractice.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            EmployeeDBEntities db = new EmployeeDBEntities();
            var data = db.Employees.ToList();
            return View(data);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee e)
        {
            EmployeeDBEntities db = new EmployeeDBEntities();
            db.Employees.Add(e);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int Id)
        {
            EmployeeDBEntities db = new EmployeeDBEntities();
            var employee = (from emp in db.Employees where emp.Id == Id select emp).FirstOrDefault();
            return View(employee);

        }

    }

}
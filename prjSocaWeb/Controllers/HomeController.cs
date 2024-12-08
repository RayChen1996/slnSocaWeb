using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using prjSocaWeb.Models;
namespace prjSocaWeb.Controllers
{
    public class HomeController : Controller
    {
        dbSocawebEntities db = new dbSocawebEntities();
        public ActionResult Index()
        {
            var emps = db.tEmp.OrderByDescending(e => e.Id).ToList();
            return View(emps);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Create()
        {
         

            return View();
        }
        [HttpPost]
        public ActionResult Create(tEmp emp)
        {
            db.tEmp.Add(emp);
            db.SaveChanges();

            return RedirectToAction("Index");
        }



        public ActionResult Delete(int id) {
            var emp = db.tEmp.FirstOrDefault(e => e.Id == id);
            db.tEmp.Remove(emp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Edit(int id)
        {
            var emp = db.tEmp.FirstOrDefault(e => e.Id == id);
            
            return View(emp);
        }

        [HttpPost]
        public ActionResult Edit(tEmp emp)
        {
             
            int id = emp.Id;
            var newEmp = db.tEmp.FirstOrDefault(x=>x.Id == id);
            newEmp.fEmpId = emp.fEmpId;
            newEmp.fName = emp.fName;   
            newEmp.fSalary = emp.fSalary;
            db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
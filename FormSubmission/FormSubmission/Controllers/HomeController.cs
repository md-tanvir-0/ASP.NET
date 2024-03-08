using FormSubmission.EF;
using FormSubmission.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FormSubmission.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View(new Person());
        }
        public ActionResult List()
        {
            var db = new FormEntities();
            var data = db.Users.ToList();
            
            return View(data);
        }
        [HttpPost]
        public ActionResult Index(User p)
        {
           
                var db = new FormEntities();
                db.Users.Add(p);
                db.SaveChanges();
                
            
            return View(p);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var db = new FormEntities();
            var data = db.Users.Find(id);
            #region delete
            //db.Users.Remove(data);
            //db.SaveChanges();
            #endregion
            //(from d in db.Departments where d.Id == id select d).SingleOrDefault();
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(User upObj)
        {
            var db = new FormEntities();
            var exobj = db.Users.Find(upObj.Id);
            exobj.Name = upObj.Name;
            exobj.Email = upObj.Email;
            db.SaveChanges();
            return RedirectToAction("List");
        }
        public ActionResult Details(int id)
        {
            var db = new FormEntities();
            var exobj = db.Users.Find(id);
            //var courses = (from c in db.Courses
            //              where c.DeptId == id
            //              select c).ToList();
            //ViewBag.Courses = courses;  
            return View(exobj);
        }

        public ActionResult Delete(int id)
        {
            var db = new FormEntities();
            var user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View("Delete", user);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var db = new FormEntities();
            var user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("List");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lab2.Controllers
{
    public class FormController : Controller
    {
        // GET: Form
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Form()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Form(FormCollection fc)
        {
            //var temp = Request["Username"];
            ViewBag.Uname = fc["Username"];
            ViewBag.Pass = fc["Password"];
            ViewBag.male = fc["male"];
            ViewBag.female = fc["female"];
            ViewBag.teac = fc["teacher"];
            ViewBag.stud = fc["student"];
            ViewBag.movie = fc["movie"];
            ViewBag.ride = fc["ride"];
            ViewBag.reading = fc["reading"];
            ViewBag.game = fc["game"];
            ViewBag.Profession = fc["Profession"];


            return View();
        }
        public ActionResult LoginSubmit()
        {
            //validation
            //authentication
            //redirection
            TempData["Msg"] = "Login Successfull";
            //return Redirect("https://www.aiub.edu");
            return RedirectToAction("Index", "Dashboard");
            //return null;
        }
    }
}
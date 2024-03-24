using LabPerfom.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LabPerfom.Controllers
{
    public class CRLoginController : Controller
    {
        // GET: CRLogin
        public ActionResult Index()
        {
            return View();

        }
        [HttpGet]
        public ActionResult login() 
        {


            return View();  
        }
        [HttpPost]
        public ActionResult login(LoginDTO l)
        {


            return View();
        }
    }
}
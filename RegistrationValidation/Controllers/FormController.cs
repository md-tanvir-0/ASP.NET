using System;
using System.Web.Mvc;
using lab2.Models;

namespace lab2.Controllers
{
    public class FormController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration(RegistrationModel Form)
        {
            if (ModelState.IsValid)
            {
                ViewBag.SuccessMessage = "Registration successful!";
                ViewBag.Name = Form.Name;
                ViewBag.ID = Form.ID;
                ViewBag.Email = Form.Email;
                ViewBag.Password = Form.Password;
                ViewBag.Birthday = Form.Birthday;

                return View();

            }

            // If the model state is not valid, return to the registration view with errors.
            return View(Form);
        }


    }
}

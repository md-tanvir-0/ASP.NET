using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZeroH.DTOs;
using ZeroH.EF;

namespace ZeroH.Controllers
{
    public class LoginController : Controller
    {
        HungerEntities db = new HungerEntities();
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(LoginDTO l)
        {
            var user = (from u in db.LoginLogs
                        where u.Username.Equals(l.Username)
                        && u.Password.Equals(l.Password)
                        select u).SingleOrDefault();
            if (user != null)
            {
                if (user.User_Type.Equals("Admin"))
                {
                    return RedirectToAction("FoodItem", "NGO");
                }
                if (user.User_Type.Equals("Restaurant"))
                {
                    var restaurant = (from u in db.Restaurants
                                      where u.ResturantLog_ID.Equals(user.Log_ID)
                                      select u).SingleOrDefault();
                    Session["restaurant"] = restaurant;
                    Session["User"] = user;
                    return RedirectToAction("FoodItem", "FoodItem");
                }

                return RedirectToAction("Index", "Home");

            }
            TempData["Msg"] = "Invalid username and password";
            return RedirectToAction("Index");

        }
    }
}
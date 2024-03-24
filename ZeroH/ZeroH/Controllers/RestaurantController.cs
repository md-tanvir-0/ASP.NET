using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZeroH.DTOs;
using ZeroH.EF;

namespace ZeroH.Controllers
{
    public class RestaurantController : Controller
    {
        HungerEntities db = new HungerEntities();
        // GET: Restaurant
        public ActionResult Index()
        {
            var data = (LoginLog)Session["User"];
            //var data = db.Foods.ToList();
            var filteredData = db.Restaurants.Where(f => f.ResturantLog_ID == data.Log_ID).ToList();

            return View(Convert(filteredData));
        }

        [HttpGet]
        public ActionResult Restaurant()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult Restaurant(RestaurantDTO R)
        {
            var data = Convert(R);
            db.Restaurants.Add(data);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Registration()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Registration(RestaurantDTO r)
        {
            // Create a new LoginLogDTO instance and assign the Username and Password
            if (ModelState.IsValid) // Ensure the model state is valid
            {
                // Create a new LoginLogDTO instance and assign the Username and Password
                var loginLogDto = new LoginLogDTO
                {
                    Username = r.LoginLog.Username, // Assign the Username entered in the form
                    Password = r.LoginLog.Password, // Assign the Password entered in the form
                    User_Type = "Restaurant" // Assuming the user type is "Restaurant"
                };

                // Convert the LoginLogDTO to LoginLog entity
                var loginLogEntity = Convert(loginLogDto);

                // Add the loginLogEntity to the LoginLogs table
                db.LoginLogs.Add(loginLogEntity);
                db.SaveChanges();

                var restaurantDto = new RestaurantDTO
                {
                    Name = r.Name,
                    ContactInformation = r.ContactInformation,
                    Address = r.Address,
                    City = r.City,
                };
                // Convert the RestaurantDTO to Restaurant entity
                var restaurantEntity = Convert(r);

                // Assign the LoginLog reference to the restaurantEntity
                restaurantEntity.LoginLog = loginLogEntity;

                // Add the restaurantEntity to the Restaurants table
                db.Restaurants.Add(restaurantEntity);
                db.SaveChanges();

                // Redirect to a success page or perform any other action as needed
                return RedirectToAction("Index", "Home"); // Redirect to the home page, for example
            }

            // If the model state is not valid, return the registration view with errors
            return View(r);
        }




        public static RestaurantDTO Convert(Restaurant r)
        {
            return new RestaurantDTO
            {

                Name = r.Name,
                ContactInformation = r.ContactInformation,
                Address = r.Address,
                City = r.City,
            };
        }

        public static Restaurant Convert(RestaurantDTO r)
        {
           
            return new Restaurant
            {
                
                Name = r.Name,
                ContactInformation = r.ContactInformation,
                Address = r.Address,
                City = r.City,
                
            };
        }

        public static List<RestaurantDTO> Convert(List<Restaurant> data)
        {
            var List = new List<RestaurantDTO>();
            foreach (var item in data)
            {
                List.Add(Convert(item));
            }
            return List;

        }



        public static LoginLogDTO Convert(LoginLog r)
        {
            return new LoginLogDTO
            {
                Username = r.Username,
                Password = r.Password,
                User_Type = r.User_Type,
            };
        }

        public static LoginLog Convert(LoginLogDTO r)
        {
            return new LoginLog
            {
                Username = r.Username,
                Password = r.Password,
                User_Type = r.User_Type,
            };
        }

        public static List<LoginLogDTO> Convert(List<LoginLog> data)
        {
            var List = new List<LoginLogDTO>();
            foreach (var item in data)
            {
                List.Add(Convert(item));
            }
            return List;

        }


    }
}
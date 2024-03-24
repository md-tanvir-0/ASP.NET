using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZeroH.DTOs;
using ZeroH.EF;

namespace ZeroH.Controllers
{
    public class CollectRequestController : Controller
    {
        HungerEntities db = new HungerEntities();
        // GET: CollectItem
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CollectRequest()
        {

            var foods = db.FoodItems.Where(f => f.Status == "Assigned").ToList();
            ViewBag.Foods = foods;

            var employees = db.Employees.Where(f => f.Status == "free").ToList();
            ViewBag.Employees = employees;

            ViewBag.Admin = (LoginLog)Session["User"];

            return View();
        }


        [HttpPost]
        public ActionResult CollectRequest (CollectRequestDTO a)
        {
            var data = Convert(a);
            db.CollectRequests.Add(data);
            db.SaveChanges();

            var food = (from u in db.FoodItems
                        where u.FoodItem_ID.Equals(a.Food_ID)
                        select u).SingleOrDefault();
            food.Status = a.FoodItem.Status;
            db.SaveChanges();

            return RedirectToAction("CollectRequest");
        }

        public static CollectRequestDTO Convert(CollectRequest r)
        {
            return new CollectRequestDTO
            {
                Request_ID = r.Request_ID,
                Assignee_ID = r.Assignee_ID,
                Food_ID = r.Food_ID,
                Restaurant_ID = r.Restaurant_ID,
                FoodItem = r.FoodItem,
                Restaurant = r.Restaurant,
                Employee = r.Employee,
                

            };
        }

        public static CollectRequest Convert(CollectRequestDTO r)
        {
            return new CollectRequest
            {
               
                Assignee_ID = r.Assignee_ID,
                Food_ID = r.Food_ID,
                Restaurant_ID = r.Restaurant_ID,
                

            };
        }

        public static List<CollectRequestDTO> Convert(List<CollectRequest> data)
        {
            var List = new List<CollectRequestDTO>();
            foreach (var item in data)
            {
                List.Add(Convert(item));
            }
            return List;

        }

        public ActionResult Delivered()
        {

            var filteredData = db.CollectRequests.Where(f => f.FoodItem.Status == "OnDelivery").ToList();
            return View(Convert(filteredData));

        }
    }
}
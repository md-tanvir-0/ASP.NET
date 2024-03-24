using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZeroH.DTOs;
using ZeroH.EF;

namespace ZeroH.Controllers
{
    public class FoodItemController : Controller
    {
        HungerEntities db = new HungerEntities();
        public ActionResult Index()
        {
            var data = (LoginLog)Session["User"];
            //var data = db.Foods.ToList();
            var filteredData = db.FoodItems.Where(f => f.LogRequest_ID == data.Log_ID).ToList();

            return View(Convert(filteredData));
        }

        [HttpGet]
        public ActionResult FoodItem()
        {
            ViewBag.data = (LoginLog)Session["User"];
            ViewBag.data2 = (Restaurant)Session["restaurant"];

            return View();
        }

        [HttpPost]
        public ActionResult FoodItem(FoodItemDTO f)
        {
            var data = Convert(f);
            db.FoodItems.Add(data);
            db.SaveChanges();


            return RedirectToAction("Index");
        }



        public static FoodItemDTO Convert(FoodItem r)
        {
            return new FoodItemDTO
            {
                FoodItem_ID = r.FoodItem_ID,
                FoodName =r.FoodName,
                Quantity =r.Quantity,
                ExpiryDate =r.ExpiryDate,
                R_ID = r.R_ID,
                LogRequest_ID = r.LogRequest_ID,
                Status =r.Status,
                Restaurant = r.Restaurant,
                LoginLog = r.LoginLog,

            };
        }

        public static FoodItem Convert(FoodItemDTO r)
        {
            return new FoodItem
            {
                FoodItem_ID = r.FoodItem_ID,
                FoodName = r.FoodName,
                Quantity = r.Quantity,
                ExpiryDate = r.ExpiryDate,
                R_ID = r.R_ID,
                LogRequest_ID = r.LogRequest_ID,
                Status = "Pending",


            };
        }

        public static List<FoodItemDTO> Convert(List<FoodItem> data)
        {
            var List = new List<FoodItemDTO>();
            foreach (var item in data)
            {
                List.Add(Convert(item));
            }
            return List;

        }
    }
}
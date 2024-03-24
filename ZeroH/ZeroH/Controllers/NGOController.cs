using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZeroH.EF;
using ZeroH.DTOs;

namespace ZeroH.Controllers
{
    public class NGOController : Controller
    {
        HungerEntities db = new HungerEntities();
        // GET: NGO
        public ActionResult Index()
        {
            var data = db.FoodItems.ToList();

            return View(Convert(data));
        }



        [HttpGet]
        public ActionResult FoodItem()
        {
            var Food = db.FoodItems.Where(f => f.Status == "Pending").ToList();
            ViewBag.FoodItems = Convert(Food);
            ViewBag.Admin = (LoginLog)Session["User"];
            return View();
        }




        [HttpPost]
        public ActionResult FoodItem(FoodItemDTO f)
        {
            var data = Convert(f);

            var food = (from u in db.FoodItems
                        where u.FoodItem_ID.Equals(data.FoodItem_ID)
                        select u).SingleOrDefault();
                        food.Status = data.Status;
                        db.SaveChanges();


            return RedirectToAction("FoodItem");
        }



        public static FoodItemDTO Convert(FoodItem r)
        {
            return new FoodItemDTO
            {
                FoodItem_ID = r.FoodItem_ID,
                FoodName = r.FoodName,
                Quantity = r.Quantity,
                ExpiryDate = r.ExpiryDate,
                R_ID = r.R_ID,
                LogRequest_ID = r.LogRequest_ID,
                Status = r.Status,
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
                Status = "Assigned",




            };
        }
        public static LoginLogDTO Convert(LoginLog dto)
        {
            return new LoginLogDTO
            {
                Username = dto.Username,
                Password = dto.Password,
                User_Type = dto.User_Type,
            };
        }

        public static LoginLog Convert(LoginLogDTO dto)
        {
            return new LoginLog
            {
                Username = dto.Username,
                Password = dto.Password,
                User_Type = "Employee",
            };
        }
        public static EmployeeDTO Convert(Employee r)
        {
            return new EmployeeDTO
            {

                Name = r.Name,
                ContactInformation = r.ContactInformation,
               EmployeeLog_ID = r.EmployeeLog_ID,
               Employee_ID = r.Employee_ID,
            };
        }

        public static Employee Convert(EmployeeDTO r)
        {

            return new Employee
            {

                Name = r.Name,
                ContactInformation = r.ContactInformation,
                EmployeeLog_ID = r.EmployeeLog_ID,
                Employee_ID = r.Employee_ID,
                

            };
        }

        public static List<EmployeeDTO> Convert(List<Employee> data)
        {
            var List = new List<EmployeeDTO>();
            foreach (var item in data)
            {
                List.Add(Convert(item));
            }
            return List;

        }

        [HttpGet]
        public ActionResult AddEmployee()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddEmployee(EmployeeDTO r)
        {
            
            if (ModelState.IsValid) 
            {
                
                var loginLogDto = new LoginLogDTO
                {
                    Username = r.LoginLog.Username, 
                    Password = r.LoginLog.Password, 
                    User_Type = "Restaurant"
                };

                
                var loginLogEntity = Convert(loginLogDto);

                db.LoginLogs.Add(loginLogEntity);
                db.SaveChanges();

                var employeeDto = new EmployeeDTO
                {
                    Name = r.Name,
                    ContactInformation = r.ContactInformation,
                    EmployeeLog_ID = r.EmployeeLog_ID,
                    Employee_ID = r.Employee_ID,
                };
                
                var employeeEntity = Convert(r);

                
                employeeEntity.LoginLog = loginLogEntity;

                
                db.Employees.Add(employeeEntity);
                db.SaveChanges();

                
                return RedirectToAction("Index", "Home"); 
            }

            
            return View(r);
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
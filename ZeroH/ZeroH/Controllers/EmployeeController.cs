using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZeroH.DTOs;
using ZeroH.EF;

namespace ZeroH.Controllers
{
    public class EmployeeController : Controller
    {
        HungerEntities db = new HungerEntities();
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public ActionResult EmployeeAssign()
        {
            ViewBag.Admin = (LoginLog)Session["User"];
            return View();
        }

        [HttpPost]
        public ActionResult EmployeeAssign(EmployeeDTO e)
        {
            var data = RestaurantController.Convert(e.LoginLog);
            data.Username = e.Name;
            db.LoginLogs.Add(RestaurantController.Convert(data));
            db.SaveChanges();

            var data2 = Convert(e);
            db.Employees.Add(data2);
            db.SaveChanges();
            return View();
        }




        public static EmployeeDTO Convert(Employee r)
        {
            return new EmployeeDTO
            {

                name = r.name,

            };
        }

        public static Employee Convert(EmployeeDTO r)
        {
            ZeroHungerV2Entities db1 = new ZeroHungerV2Entities();
            var user = db1.users.FirstOrDefault(u => u.Uname == r.name && u.pass == r.user.pass);

            return new Employee
            {
                uid = user.id,
                name = r.name,
                contact = r.contact,
                status = r.status,
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
        public ActionResult EmployeeFood()
        {
            var user = (user)Session["User"];

            var filteredData = db.Approveds.Where(f => f.Employee.uid == user.id && f.Food.status != "Delivered").ToList();
            ViewBag.emp = (user)Session["User"];
            return View(ApprovedController.Convert(filteredData));
        }

        [HttpPost]

        public ActionResult EmployeeFood(ApprovedDTO a)
        {


            var food = (from u in db.Foods
                        where u.id.Equals(a.Fid)
                        select u).SingleOrDefault();
            food.status = a.Food.status;
            db.SaveChanges();


            var data = Convert(a);


            var aprv = (from u in db.Approveds
                        where u.id.Equals(data.id)
                        select u).SingleOrDefault();
            aprv.deliveredtime = data.deliveredtime;
            db.SaveChanges();


            return RedirectToAction("EmployeeFood");
        }

        public static ApprovedDTO Convert(Approved r)
        {
            return new ApprovedDTO
            {
                id = r.id,
                Eid = r.Eid,
                Fid = r.Fid,
                Rid = r.Rid,
                Food = r.Food,
                Restaurant = r.Restaurant,
                Employee = r.Employee,

            };
        }

        public static Approved Convert(ApprovedDTO r)
        {
            return new Approved
            {
                id = r.id,
                Eid = r.Eid,
                Fid = r.Fid,
                Rid = r.Rid,
                Food = r.Food,
                Restaurant = r.Restaurant,
                Employee = r.Employee,
                deliveredtime = DateTime.Now,




            };
        }

        public static List<ApprovedDTO> Convert(List<Approved> data)
        {
            var List = new List<ApprovedDTO>();
            foreach (var item in data)
            {
                List.Add(Convert(item));
            }
            return List;

        }

    }
}
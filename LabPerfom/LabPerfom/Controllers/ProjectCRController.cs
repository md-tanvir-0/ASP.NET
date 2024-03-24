using LabPerfom.DTO;
using LabPerfom.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LabPerfom.Controllers
{
    public class ProjectCRController : Controller
    {
        Entities db=new Entities();
        // GET: CR
        public ActionResult Index()
        {
            var data = db.Projects.ToList();
            ViewBag.Project = Convert(data);
            return View();
        }

        [HttpGet]
        public ActionResult AddProject() 
        {
            //var data=db.Projects.ToList();
            //ViewBag.Project = Convert(data);
            return View();
        }

        [HttpPost]
        public ActionResult AddProject(ProjectDTO p)
        {
            var data = Convert(p);
            db.Projects.Add(data);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public static ProjectDTO Convert(Project p) 
        {
            return new ProjectDTO 
            {
                id=p.id,
                title=p.title,
                deadline=p.deadline,
                description=p.description,
                status=p.status,
                PCId=p.PCId,
                AId=p.AId,
            };
        }


        public static Project Convert(ProjectDTO p)
        {
            return new Project
            {
                id = p.id,
                title = p.title,
                deadline = p.deadline,
                description = p.description,
                status = p.status,
                PCId = p.PCId,
                AId = p.AId,
            };
        }


        public static List<ProjectDTO> Convert(List<Project> data) 
        {
            var list = new List<ProjectDTO>();
            foreach (var item in data)
            {
                list.Add(Convert(item));
            }

            return list;

        }

    }
}
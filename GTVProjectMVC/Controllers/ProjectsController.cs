using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BussinessLayer;
using ModelEntity;

namespace GTVProjectMVC.Controllers
{
    public class ProjectsController : Controller
    {
        public ActionResult AddProject()
        {
            return View();
        }

        public ActionResult AddProjectTask()
        {
            ProjectModel modelOBj = new ProjectModel();
            ProjectBusiness busobj = new ProjectBusiness();
            modelOBj = busobj.GetProjectDetails();

            return View(modelOBj);
        }
        public ActionResult ProjectsTaskDisplay()
        {
            ProjectModel modelOBj = new ProjectModel();
            ProjectBusiness busobj = new ProjectBusiness();
            modelOBj = busobj.GetProjectDetails();

            return View(modelOBj);
       
        }

  
       
    }
}
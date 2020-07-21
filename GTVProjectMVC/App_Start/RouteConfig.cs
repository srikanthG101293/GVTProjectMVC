using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace GTVProjectMVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
            name: "Default",
            url: "{controller}/{action}/{id}",
            defaults: new { controller = "Projects", action = "AddProject", id = UrlParameter.Optional });

            //routes.MapRoute(
            //name: "AddProject",
            //url: "Add-Project",
            //defaults: new { controller = "Projects", action = "AddProject" });

            //routes.MapRoute(
            //name: "AddProjecttask",
            //url: "Add-Project-task",
            //defaults: new { controller = "Projects", action = "AddProjectTasks" });

            //routes.MapRoute(
            //name: "proh",
            //url: "get-Project-tasks",
            //defaults: new { controller = "Projects", action = "ProjectsTaskDisplay" });
        }
    }
}

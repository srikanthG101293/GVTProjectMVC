using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ModelEntity;
using BussinessLayer;
namespace GTVProjectMVC
{
    /// <summary>
    /// Summary description for Projects
    /// </summary>
    public class Projects : IHttpHandler
    {

       

        public void ProcessRequest(HttpContext context)
        {

            ProjectParams objparam = new ProjectParams();
            try
            {


                int type = Convert.ToInt32(context.Request["type"]);
              

                string res = string.Empty;
                switch (type)
                {

                    case 1:
                        string taskTitle = Convert.ToString(context.Request["taskTitle"]);
                        int ProjectID = Convert.ToInt32(context.Request["ProjectID"]);
                        int taskHours = Convert.ToInt32(context.Request["taskHours"]);

                        objparam.TaskTitle = taskTitle;
                        objparam.ProjectID = ProjectID;
                        objparam.TaskHours = taskHours;

                        res = SaveProjectTaskDetails(objparam);
                        context.Response.ContentType = "text/json";
                        context.Response.Write(res);
                        break;
                    case 2:
                        string ProjectDescription = Convert.ToString(context.Request["ProjectDescription"]);
                        string ProjectTitle = Convert.ToString(context.Request["ProjectTitle"]);
                        objparam.ProjectName = ProjectTitle;
                        objparam.ProjectDescription = ProjectDescription;

                        res = SaveProjectDetails(objparam);
                        context.Response.ContentType = "text/json";
                        context.Response.Write(res);
                        break;


                }

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public string SaveProjectTaskDetails(ProjectParams objparam)
        {
            string res = string.Empty;
            ProjectBusiness proObj = new ProjectBusiness();
            try
            {
                res = proObj.AddProjectTasks(objparam);
            return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public string SaveProjectDetails(ProjectParams objparam)
        {
            string res = string.Empty;
            ProjectBusiness proObj = new ProjectBusiness();
            try
            {
                res = proObj.AddProject(objparam);
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using ModelEntity;
using System.Data;

namespace BussinessLayer
{
    public class ProjectBusiness
    {
        ProjectEntity obj = new ProjectEntity();
       

        public ProjectModel GetProjectDetails ()
        {     
            int RetVal = 0;
            DataSet ds = new DataSet();
            ProjectModel modelObj = new ProjectModel();
            try
            {
                ds = obj.GetProjectDetails();
                if (ds.Tables.Count > 0)
                {
                    modelObj.ProjectParams = BusinessHelper.DataTableToList<ProjectParams>(ds.Tables[0]);
                    modelObj.ProjectDetails = BusinessHelper.DataTableToList<ProjectDetails>(ds.Tables[1]);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return modelObj;
        }

        public string AddProjectTasks(ProjectParams param)
        {
            int RetVal = 0;
            string result = string.Empty;
            try
            {
                obj.AddProjectTasks(param, out RetVal);

                result = "{\"RetVal\":\"" + RetVal + "\"}";
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }
        public string AddProject(ProjectParams param)
        {
            int RetVal = 0;
            string result = string.Empty;
            try
            {
                obj.AddProject(param, out RetVal);

                result = "{\"RetVal\":\"" + RetVal + "\"}";
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

    }
}

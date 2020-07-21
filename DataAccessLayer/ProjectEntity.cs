using ModelEntity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ProjectEntity
    {
        static string strConnString = ConfigurationManager.ConnectionStrings["DBconnection"].ConnectionString;

     
        SqlDataAdapter da = new SqlDataAdapter();
        SqlDataReader dr;
        SqlConnection sqlcon = new SqlConnection(strConnString);
        SqlCommand sqlcmd = default(SqlCommand);

        public DataSet GetProjectDetails()
        {
            DataSet ds = new DataSet();

            string result = string.Empty;
            try
            {
                sqlcmd = new SqlCommand("SP_GetProjectsAndTasks", sqlcon);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                da.SelectCommand = sqlcmd;
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlcon.Close();
                sqlcon.Dispose();
            }
            return ds;
        }

        public void AddProjectTasks(ProjectParams ParamObj,out int RetVal)
        {

             //int RetVal = 0;
            int result = 0;
            try
            {
                sqlcmd = new SqlCommand("SP_SaveProjectTasks", sqlcon);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.Add("@ProjectID", SqlDbType.Int).Value = ParamObj.ProjectID;
                sqlcmd.Parameters.Add("@TaskHours", SqlDbType.Int).Value = ParamObj.TaskHours;
                sqlcmd.Parameters.Add("@TaskTitle", SqlDbType.VarChar, 250).Value = ParamObj.TaskTitle;
                sqlcmd.Parameters.Add("@RetVal", SqlDbType.Int).Direction = ParameterDirection.Output;
                da.SelectCommand = sqlcmd;
                sqlcon.Open();
                result = sqlcmd.ExecuteNonQuery();
                sqlcon.Close();
                RetVal = Convert.ToInt32(sqlcmd.Parameters["@RetVal"].Value);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AddProject(ProjectParams ParamObj, out int RetVal)
        {

            //int RetVal = 0;
            int result = 0;
            try
            {
                sqlcmd = new SqlCommand("SP_SaveProject", sqlcon);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.Add("@ProjectName", SqlDbType.VarChar, 250).Value = ParamObj.ProjectName;
                sqlcmd.Parameters.Add("@ProjectDescription", SqlDbType.VarChar, 250).Value = ParamObj.ProjectDescription;

                sqlcmd.Parameters.Add("@RetVal", SqlDbType.Int).Direction = ParameterDirection.Output;
                da.SelectCommand = sqlcmd;
                sqlcon.Open();
                result = sqlcmd.ExecuteNonQuery();
                sqlcon.Close();
                RetVal = Convert.ToInt32(sqlcmd.Parameters["@RetVal"].Value);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}

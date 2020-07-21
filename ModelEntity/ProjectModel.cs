using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEntity
{
    public class ProjectModel
    {
        public List<ProjectParams> ProjectParams { get; set; }
        public List<ProjectDetails> ProjectDetails { get; set; }

    }
    public class ProjectParams
    {


        public int ProjectID { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        [Required(ErrorMessage = "Please Enter Task Tile")]
        public string TaskTitle { get; set; }
        public int TaskHours { get; set; }
    }

    public class ProjectDetails
    {
        public int ProjectID { get; set; }
        public string ProjectTitle { get; set; }
        public string ProjectDescription { get; set; }

    }


    }

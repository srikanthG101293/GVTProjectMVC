using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace GTVProjectMVC.Models
{
    public class ProjectTask
    {
        public int ProjectID { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        [Required(ErrorMessage ="Please Enter Task Tile")]
        public string TaskTitle { get; set; }   
        public int TaskHours { get; set; }
    }
}
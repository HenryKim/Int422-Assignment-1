using Assignment.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment.ViewModels
{

    public class AddServiceRequest 
    {
        [Required]
        [StringLength(9)]
        [Display(Name = "Student Number")]
        public string StudentNumber { get; set; }

        [Required]
        [Display(Name = "Program")]
        public ICollection<SelectListItem> Program { get; set; }

        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }
        
        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Category")]
        public ICollection<SelectListItem> Category { get; set; }
        
        public AddServiceRequest()
        {
            Program = new List<SelectListItem>();
            Category = new List<SelectListItem>();

        }
        //file attachement (possible feature)      
    }

    public class ServiceRequestAdd
    {
        [Required]
        [StringLength(9)]
        [Display(Name = "Student Number")]
        public string StudentNumber { get; set; }

        [Required]
        [Display(Name = "Program")]
        public int ProgramId { get; set; }

        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Category")]
        public String Category { get; set; }


        //file attachement (possible feature)      
    }

    public class ServiceRequestDetail
    {
        public int Id { get; set; }
        public Student student { get; set; }
        public Program program { get; set; } 
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Notes { get; set; }
        public string Priority { get; set; }
        [Display(Name = "Date logged")]
        public DateTime DateLogged { get; set; }
        [Display(Name = "Date updated")]
        public DateTime DateUpdated { get; set; }
        public string Status { get; set; }

        public ServiceRequestDetail()
        {
            Status = "Open";

        }
    }

    public class ServiceRequestList
    {

        public int Id { get; set; }

        [Display(Name = "Student Name")]
        //public string studentName { get; set; }
        public Student student { get; set; }
        
        [Display(Name = "Program")]
        //public string program { get; set; }
        public Program program { get; set; }

        [Display(Name = "Date Logged")]
        public DateTime dateLogged { get; set; }

        [Display(Name = "Request Status")]
        public string status { get; set; }
        [Display(Name = "Request Title")]
        public string Title { get; set; }

        [Display(Name = "Priority")]
        public string priority { get; set; }
    }

    public class ServiceRequestEdit:ServiceRequestAdd
    {
        public int Id { get; set; }

        [Display(Name = "Date Updated")]
        public DateTime DateUpdate { get; set; }
        [Display(Name = "Date Logged")]
        public DateTime DateLogged { get; set; }
        [Display(Name = "Status")]
        public string status { get; set; }

        [Display(Name = "Priority")]
        public string priority { get; set; }

        [Display(Name = "Note")]
        public string note { get; set; }
    }
    public class ServiceReportForm : ServiceRequestList
    {
        [Display(Name = "Service Released From")]
        public DateTime fromDate { get; set; }

        [Display(Name = "To")]
        public DateTime toDate { get; set; }
    }

}
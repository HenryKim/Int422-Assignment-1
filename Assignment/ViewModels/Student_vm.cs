using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assignment.ViewModels
{
    public class StudentList
    {
        public int Id { get; set; }

        [Display(Name = "Student's Student Number")]
        public string StudentNumber { get; set; }

        [Display(Name = "Student's First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Student's Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Student's  User name")]
        public string Username { get; set; }

        [Display(Name = " Student's Email")]
        public string Email { get; set; }
    }

    public class AddStudent
    {
        [Required]
        [Display(Name = "Student's First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Student's Last name")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Student's user name")]
        public string Username { get; set; }
        [Required]
        [Display(Name = "Student's Student Number")]
        [StringLength(9, ErrorMessage = "{0} is {1} digits long")] 
        public string StudentNumber { get; set; }
        [Required]
        [Display(Name = "Student's  Email")]
        public string Email { get; set; }
    }

    public class StudentBase : AddStudent
    {
        public int Id { set; get; }
    }


}
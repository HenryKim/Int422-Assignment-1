using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assignment.Models
{
    /* This class files for
     * Appdomain class declaration
     * */
    public class Student
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string StudentNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
      
    }

    public class Program
    {
        public int Id { get; set; }

        [Display(Name = "Program Code")]
        public string ProgramCode { get; set; }

        [Display(Name = "Program Description")]
        public string ProgramDescription { get; set; }
    }

    public class ServiceRequest
    {
       public int Id { get; set; }

       public Student student { get; set; }
       public Program program { get; set; }
       public DateTime DateLogged { get; set; }
       public DateTime DateUpdated { get; set; }

       public string Category { get; set; }
       public string Description { get; set; }
       public string Notes { get; set; }
       public string Priority { get; set; }
       public string Status { get; set; }
       public string Title { get; set; }
    }

}
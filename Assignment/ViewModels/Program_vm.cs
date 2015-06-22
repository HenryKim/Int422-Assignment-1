using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assignment.ViewModels
{
    public class AddProgram
    {
        [Required]
        [Display(Name = "Program Code")]
        public string ProgramCode { get; set; }

        [Required]
        [Display(Name = "Program Description")]
        public string ProgramDescription { get; set; }
    }

    public class ProgramList
    {
        
        public int Id { get; set; }

        [Display(Name = "Program Code")]
        public string ProgramCode { get; set; }

        [Display(Name = "Program Description")]
        public string ProgramDescription { get; set; }
    }

    public class ProgramBase : AddProgram
    {
        public int Id { get; set; }

    }

    


}
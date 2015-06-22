using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Assignment.Models
{
    public class StoreInitializer : DropCreateDatabaseAlways<DataContext>
    {
        // THis function will initalized all DB item for use by defaults
        protected override void Seed(DataContext context)
        {
     
           var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
           var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
 
           if (!RoleManager.RoleExists("Admin"))
           {
               var roleresult = RoleManager.Create(new IdentityRole("Admin"));
           }
           
            //Create User = Admin with password=123456
            var user = new ApplicationUser();
            user.UserName = "Admin";
            var adminresult = UserManager.Create(user, "123456");

            if (adminresult.Succeeded)
            {
                var result = UserManager.AddToRole(user.Id, "Admin");
            }

            if (!RoleManager.RoleExists("Coordinator"))
            {
                var roleresult2 = RoleManager.Create(new IdentityRole("Coordinator"));
            }

            var user2 = new ApplicationUser();
            user2.UserName = "IanTipson";
            var Cordresult2 = UserManager.Create(user2, "password1");

            if (Cordresult2.Succeeded)
            {
                var result = UserManager.AddToRole(user2.Id, "Coordinator");
            }

            var user3 = new ApplicationUser();
            user3.UserName = "ScottApted";
            var Cordresult3 = UserManager.Create(user3, "password2");

            if (Cordresult3.Succeeded)
            {
                var result = UserManager.AddToRole(user3.Id, "Coordinator");
            }

            var user4 = new ApplicationUser();
            user4.UserName = "PatHarper";
            var Cordresult4 = UserManager.Create(user4, "password3");


            if (Cordresult4.Succeeded)
            {
                var result = UserManager.AddToRole(user4.Id, "Coordinator");
            }

            var user5 = new ApplicationUser();
            user5.UserName = "TimMcKenna";
            var Cordresult5 = UserManager.Create(user5, "password5");

            if (Cordresult5.Succeeded)
            {
                var result = UserManager.AddToRole(user5.Id, "Coordinator");
            }



            var user6 = new ApplicationUser();
            user6.UserName = "PeterMcIntyre";
            var Cordresult6 = UserManager.Create(user6, "password6");


            if (Cordresult6.Succeeded)
            {
                var result = UserManager.AddToRole(user6.Id, "Coordinator");
            }




            //Students
            Student student1 = new Student()
            {
                FirstName = "A",
                LastName = "AA",
                StudentNumber = "117622234",
                Email = "AA@myseneca.ca",
                Username = "AA"
            };
            context.Student.Add(student1);

            Student student2 = new Student()
            {
                FirstName = "BB",
                LastName = "BB",
                StudentNumber = "141455324",
                Email = "BB@myseneca.ca",
                Username = "BB"
            };
            context.Student.Add(student2);

            Student student3 = new Student()
            {
                FirstName = "C",
                LastName = "CC",
                StudentNumber = "121545366",
                Email = "CC@myseneca.ca",
                Username = "CC"
            };
            context.Student.Add(student3);

            Student student4 = new Student()
            {
                FirstName = "D",
                LastName = "DD",
                StudentNumber = "484321123",
                Email = "DD@myseneca.ca",
                Username = "DD"
            };
            context.Student.Add(student4);

            Student student5 = new Student()
            {
                FirstName = "E",
                LastName = "EE",
                StudentNumber = "325654549",
                Email = "EE@myseneca.ca",
                Username = "EE"
            };
            context.Student.Add(student5);
            Student student6 = new Student()
            {
                FirstName = "Test",
                LastName = "Testing",
                StudentNumber = "125741125",
                Email = "Test@myseneca.ca",
                Username = "Test"
            };
            context.Student.Add(student6);

            context.SaveChanges();

            // Program

            Program program1 = new Program()
            {
                ProgramCode = "CPA",
                ProgramDescription = "3-Year Computer Programming And Analysis advanced diploma"
            };
            context.Program.Add(program1);

            Program program2 = new Program()
            {
                ProgramCode = "CPD",
                ProgramDescription = "2-Year Computer Programming Diploma"
            };
            context.Program.Add(program2);

            Program program3 = new Program()
            {
                ProgramCode = "CNS",
                ProgramDescription = "2-Year Computer Networking and Technical Support Diploma"
            };
            context.Program.Add(program3);

            Program program4 = new Program()
            {
                ProgramCode = "CTY",
                ProgramDescription = "3-Year Computer Systems Technology advanced diploma"
            };
            context.Program.Add(program4);

            Program program5 = new Program()
            {
                ProgramCode = "BSD",
                ProgramDescription = "4-Year Bachelor of Technology (Software Development) Degree"
            };
            context.Program.Add(program5);

            context.SaveChanges();

            // Service Requests

            ServiceRequest serviceRequest1 = new ServiceRequest()
            {
                student = student1,
                Notes = "Student 1  droping out of Jac444",
                Category = "Tile Conflict issue",
                DateLogged = DateTime.Now,
                DateUpdated = DateTime.Today,
                Description = "Droping Jac444 course",
                program = program1,
                Priority = "Urgent",
                Status = "Open",
                Title = "Droping a course",
            };

            context.ServiceRequest.Add(serviceRequest1);

            ServiceRequest serviceRequest2 = new ServiceRequest()
            {
                student = student2,
                Notes = "Currently in 3rd semester",
                Category = "Program related issue",
                DateLogged = DateTime.Now,
                DateUpdated = DateTime.Today,
                Description = "Switch Major between in same campus",
                program = program3,
                Priority = "Medium",
                Status = "Closed",
                Title = "Switching programs",
            };

            context.ServiceRequest.Add(serviceRequest2);
            context.SaveChanges();
        }
    }
}
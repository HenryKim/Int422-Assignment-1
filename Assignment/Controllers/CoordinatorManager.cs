﻿using Assignment.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment.Controllers
{
    public class CoordinatorManager
    {
        private DataContext ds = new DataContext();

        public void addCoordinator(RegisterViewModel newItem)
        {
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(ds));
            var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(ds));
            // Creat Roles for Coordinator for security purpose
            if (!RoleManager.RoleExists("Coordinator"))
            {
                var roleresult = RoleManager.Create(new IdentityRole("Coordinator"));
            }
            var user = new ApplicationUser();
            user.UserName =  newItem.UserName;
            var Cordresult = UserManager.Create(user, newItem.Password);
            if (Cordresult.Succeeded)
            {
                var result = UserManager.AddToRole(user.Id, "Coordinator");
            }
            ds.SaveChanges();       
        }
    }
}
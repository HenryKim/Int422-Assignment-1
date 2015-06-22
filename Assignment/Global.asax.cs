using Assignment.Models;
using Assignment.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Assignment
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Data store initializer
            System.Data.Entity.Database.SetInitializer(new Models.StoreInitializer());

           //ViewModel to Model
            Mapper.CreateMap<AddStudent,Student>();
            Mapper.CreateMap<AddProgram, Program>();
            Mapper.CreateMap<AddServiceRequest, ServiceRequest>();
            Mapper.CreateMap<ServiceRequestAdd, ServiceRequest>();
            Mapper.CreateMap<ServiceRequestEdit, ServiceRequest>();
            

            //Model to ViewModel
            Mapper.CreateMap<Student, StudentList>();
            Mapper.CreateMap<Student, ServiceRequest>();
            Mapper.CreateMap<Program, ServiceRequest>();
            Mapper.CreateMap<Program, ProgramList>();
            Mapper.CreateMap<Program, ProgramBase>();
            Mapper.CreateMap<ServiceRequest, Student>();
            Mapper.CreateMap<ServiceRequest, Program>();
            Mapper.CreateMap<ServiceRequest, AddServiceRequest>();
            Mapper.CreateMap<ServiceRequest, ServiceRequestAdd>();
            Mapper.CreateMap<ServiceRequest, ServiceRequestList>();
            Mapper.CreateMap<ServiceRequest, ServiceRequestDetail>();
            Mapper.CreateMap<ServiceRequest, ServiceRequestEdit>();
            Mapper.CreateMap<Program, ProgramBase>();
            Mapper.CreateMap<Student, StudentBase>();

            //ViewModel to ViewModel
            Mapper.CreateMap<ServiceRequestEdit, ServiceRequestDetail>();
            Mapper.CreateMap<ServiceRequestDetail, ServiceRequestEdit>();
        }
    }
}

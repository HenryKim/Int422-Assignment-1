using Assignment.Models;
using Assignment.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;


namespace Assignment.Controllers
{
    public class ServiceRequestManager
    {
        private DataContext ds = new DataContext();
        
        //Security: it is Authorized to Co-ordinator and admin roels only
        //Send Emails to Student, it possible add-ons.

        public ServiceRequest createServiceRequest(ServiceRequestAdd newItem)
        {
            // This function will create New service Request Page
            // will get new servies by using auto mapper by matching items

            Student sstu = ds.Student.SingleOrDefault(s => s.StudentNumber == newItem.StudentNumber);
           Program sprg = ds.Program.SingleOrDefault(p => p.Id == newItem.ProgramId);
           //Program sprg = ds.Program.Find(newItem.ProgramId);
            if (sstu == null || sprg == null)
                return null; 
            // it will automatically Update date of looged and updated.
            var service = Mapper.Map<ServiceRequest>(newItem);
            service.student = sstu;
            service.program = sprg;
            service.DateLogged = DateTime.Now;
            service.DateUpdated = DateTime.Now;
            service.Priority = "Low";
            service.Status = "Open";

            ds.ServiceRequest.Add(service);
            ds.SaveChanges();

            // it will return service back to Controller.
            return service;
        }


        
        public bool DeleteServiceRequestById(int id)
        {
            // This function will be delete existing Service by mathing id
            // Attempt to fetch the object
            // will find matching object from DB
            var fetchedObject = ds.ServiceRequest.Find(id);

            // if their is no matching object it will retrun false
            if (fetchedObject == null)
            {
                return false;
            }
            else
            {
                // if there is matching object, remove that matched obbject from DB
                // Saves the DB
                // and will return true to Controller.
                ds.ServiceRequest.Remove(fetchedObject);
                ds.SaveChanges();
                return true;
            }
        }

 
        public IEnumerable<ServiceRequestList> getAllServiceRequests()
        {
            // This function will FETCH ALL service requests from DB
            // this function done by using autommapping
            var fetchedObjects = ds.ServiceRequest.Include("Program").Include("Student").ToList();
            return Mapper.Map<IEnumerable<ServiceRequestList>>(fetchedObjects);
        }

        public IEnumerable<ServiceRequestList> getServiceRequestByDate(DateTime FromDate, DateTime ToDate)
        {
            // This function will Fecth all student by given Date Range (FromDate, ToDate)
            var fetchedObjects = ds.ServiceRequest.Where(Service => (Service.DateLogged >= FromDate && Service.DateLogged <= ToDate));
            // this function done by using automapping
            return Mapper.Map<IEnumerable<ServiceRequestList>>(fetchedObjects);
        }

        public IEnumerable<ServiceRequestList> getServiceRequestByProgram(Program program)
        {
            // This function will Fecth all ServiceRequest in given Program
            var fetchedObjects = ds.ServiceRequest.Where(Service => (Service.program.ProgramCode == program.ProgramCode));
            // This function done by using automapping
            return Mapper.Map<IEnumerable<ServiceRequestList>>(fetchedObjects);
        }


        public IEnumerable<ServiceRequestList> getServiceRequestByUserName(string username)
        {
            // This function will Fecth all ServiceRequest in given username
            var fetchedObjects = ds.ServiceRequest.Where(Service => (Service.student.Username == username));
            // This function done by using automapping
            return Mapper.Map<IEnumerable<ServiceRequestList>>(fetchedObjects);
        }


        public IEnumerable<ServiceRequestList> getServiceRequestByStudentNumber(string studentNumber)
        {
            // This function will Fecth all ServiceRequest in given Student Number
            var fetchedObjects = ds.ServiceRequest.Where(Service => (Service.student.StudentNumber == studentNumber));
            // This function done by using automapping
            return Mapper.Map<IEnumerable<ServiceRequestList>>(fetchedObjects);
        }

        
        public ServiceRequestEdit GetServiceRequestForEditById(int id)
        {
            // This function will Edit Service Request by matching Id from DB
            var fetchedObject = ds.ServiceRequest.Find(id);

            if (fetchedObject != null)
            {

                // If will get fecthed obejct by automapper that matches given id
                return Mapper.Map<ServiceRequestEdit>(fetchedObject);
            }
            else
            {
                // it will return null, if there is no matching id in DB.
                return null;
            }
        }
        


        public ServiceRequest GetServiceRequestById(int id)
        {
            // This function will Get Service Request by matching Id from DB
            var fetchedObject = ds.ServiceRequest.Find(id);

            if (fetchedObject != null)
            {
                //Student stu = ds.Student.SingleOrDefault(s => s.StudentNumber == fetchedObject.student.StudentNumber);
                //fetchedObject.student = stu;
                // If will get fecthed obejct by automapper that matches given id
                return fetchedObject;
            }
            else
            {
                // it will return null, if there is no matching id in DB.
                return null;
            }
        }

        public ServiceRequestEdit EditServiceRequest(ServiceRequestEdit newItem)
        {
            // this function for Exiting Edit page
            // Attempt to fetch the object with the matching identifier
            //var fetchedObject = this.GetServiceRequestById(newItem.Id);
            var fetchedObject = ds.ServiceRequest.Find(newItem.Id);
            //var fetchedObject = ds.ServiceRequest.SingleOrDefault(s => s.Id == newItem.Id);
            if (fetchedObject == null)
            {
                return null;
            }
            else
            {
                newItem.DateUpdate = DateTime.Now;
                newItem.DateLogged = fetchedObject.DateLogged;
                ds.Entry(fetchedObject).CurrentValues.SetValues(newItem);
                ds.SaveChanges();
                // uses automapping to map objects
                return Mapper.Map<ServiceRequestEdit>(fetchedObject);
            }
        }


    }
}
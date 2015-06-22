using Assignment.Models;
using Assignment.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment.Controllers
{
    public class ServiceRequestController : Controller
    {
        // m will be variable for Service Reaust Manager
        ServiceRequestManager m = new ServiceRequestManager();
        // It authorized to use admin and coordinator
        [Authorize(Roles = "Admin, Coordinator")]
        public ActionResult Index()
        {
            // fetch all Service Requests and send it to view.
            return View(m.getAllServiceRequests());
        }

        public ActionResult Create()
        {
            // This function will Create New Service Request Page.
            ProgramManager pm = new ProgramManager();
            AddServiceRequest sr = new AddServiceRequest();

            var programs = pm.getAllPrograms();

            foreach (var t in programs)
            {
                sr.Program.Add(new SelectListItem() { Text = t.ProgramCode, Value = "" + t.Id });
            }
            
            // add items for select list 
            sr.Category.Add(new SelectListItem() { Text = "Dropping a course" });
            sr.Category.Add(new SelectListItem() { Text = "Adding a course" });
            sr.Category.Add(new SelectListItem() { Text = "Request for advance standings" });
            sr.Category.Add(new SelectListItem() { Text = "Switching programs" });
            sr.Category.Add(new SelectListItem() { Text = "Other inquiries" });

            // it will return to View
            return View(sr);
        }
        // Uses HttpPost Methid
        [HttpPost, ValidateInput(false)]
        public ActionResult Create(ServiceRequestAdd newItem)
        {
            var serviceReq = new ServiceRequest();

            if (ModelState.IsValid)
            {
                // if model stad is valid
                serviceReq = m.createServiceRequest(newItem);

                return RedirectToAction("Details", new { Id = serviceReq.Id });
            }
            else
            {
                // if model stand wasnt valid
                return View(newItem);
            }
        }

        [Authorize(Roles = "Admin, Coordinator")] // Authorize user for security
        public ActionResult Edit(int id)
        {
            // This function will fetch service request by matching id
            // and grants Authorized user to use edit function
            ServiceRequest fetchedObject = m.GetServiceRequestById(id);

            // if there is no matching object it will redirct to Index page
            if (fetchedObject == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ServiceRequestEdit edit = new ServiceRequestEdit();
                edit.status = fetchedObject.Status;
                edit.note = fetchedObject.Notes;
                edit.priority = fetchedObject.Priority;
                //edit.StudentNumber = fetchedObject.student.StudentNumber;
                edit.Id = fetchedObject.Id;
                edit.Title = fetchedObject.Title;
                edit.DateUpdate = DateTime.Now;
                edit.Description = fetchedObject.Description;
                

                return View(m.EditServiceRequest(edit));
            }
        }

        // uses HttpPost Method
        [Authorize(Roles = "Admin, Coordinator")] // Authorize user for security
        [HttpPost, ValidateInput(false)]
        public ActionResult Edit(int id, ServiceRequestEdit newItem)
        {
            // This function will fetch service request by matching id
            // and grants Authorized user to use edit function
            if (ModelState.IsValid & id == newItem.Id)
            {
                ServiceRequestEdit editedItem = m.EditServiceRequest(newItem);

                if (editedItem == null)
                {
                    return View(newItem);
                }
                else
                {
                    return RedirectToAction("details", new { id = editedItem.Id });
                }
            }
            else
            {
                // Return the object so the user can edit it correctly
                return View(newItem);
            }
        }

        [Authorize(Roles = "Admin, Coordinator")] // Authorize user for security
        public ActionResult Delete(int? id)
        {
           // this function for delete service request from Db by matching id
             ServiceRequest itemToDelete = m.GetServiceRequestById(id.GetValueOrDefault());
             
            if (itemToDelete == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                m.DeleteServiceRequestById(itemToDelete.Id);
                return RedirectToAction("Index");
            }
        }

        [Authorize(Roles = "Admin, Coordinator")] // Authorize user for security
        [HttpPost]// uses HttpPost Method
        public ActionResult Delete(int id)
        {
            // THis function for delete service request from Db my matching id
            
            m.DeleteServiceRequestById(id);
            
            return RedirectToAction("Index");
        }

    

        [Authorize(Roles = "Admin, Coordinator")] // Authorize user for security.
        public ActionResult Details(int Id)
        {
            // this function will show detial page of Service Requst by given id
            return View(Mapper.Map<ServiceRequestDetail>(m.GetServiceRequestById(Id)));
        }
         [Authorize(Roles = "Admin, Coordinator")]
        public ActionResult ServiceRequestReport()
        {
            return View();
        }
        [HttpPost]
         public ActionResult ServiceRequestReport(ServiceReportForm newItem)
         {
             var fetchedObjects = m.getServiceRequestByDate(newItem.fromDate, newItem.toDate);
             if (fetchedObjects != null)
             {
                 // add it to the session and we'll fetch it in the next View
                 TempData["serviceRequestList"] = fetchedObjects;
                 return RedirectToAction("DisplayServiceRequestReport");
             }
             else
             {
                 return View();
             }
         }
        public ActionResult DisplayServiceRequestReport()
        {
            // fetch it form the session
            var fetchedObject = (IEnumerable<ServiceRequestList>)TempData["serviceRequestList"];
            return View(fetchedObject);
        }


    }

    
}
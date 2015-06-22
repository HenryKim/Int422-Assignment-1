using Assignment.Models;
using Assignment.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment.Controllers
{
    public class StudentController : Controller
    {
        private StudentManager m = new StudentManager();
        // m is the Student Manager variable


        [Authorize(Roles = "Admin, Coordinator")] // Set the authorized roles to access
        public ActionResult Index()
        {
            // this function will get ALL fetched student from DB(Student Manager) and pass to View 
            return View(m.getAllStudents());
        }

        [Authorize(Roles = "Admin, Coordinator")] // Set the authorized roles to access
        public ActionResult Create()
        {
            return View(); // This page will end it to Create.
        }

        // this function use HttpPost method
        [HttpPost]
        [Authorize(Roles = "Admin, Coordinator")]// Set the authorized roles to access
        public ActionResult Create(AddStudent newItem)
        {
            if (ModelState.IsValid) // if model state is valid
            {
                m.createStudent(newItem); // will send student infro to student manager to save in DB
                return RedirectToAction("index"); // and redirect to view page
            }
            else
            {
                return View(newItem); // if state is not valide it ll just return to view page with student info sented.
            }
        }


        // GET: /Student/Details/5
        [Authorize(Roles = "Admin, Coordinator")]// Set the authorized roles to access
        public ActionResult Details(int id)
        {
            var fetchedStudent = m.getStudentById(id); // this is detail view page of student ordered by ID
            // can access this viewpage by using student number INCLUDED
            // this Details are same from LAB works ( does not need additional comments...)

            if (fetchedStudent == null)
            {
                return RedirectToAction("index");
            }
            else
            {
                return View(fetchedStudent);
            }
        }

        // GET: /Student/Delete/5
        [Authorize(Roles = "Admin, Coordinator")]// Set the authorized roles to access
        public ActionResult Delete(int? id)
        {
            //this function will grant Authorized user to an use function of delete
            // this function are same from LAB work.
            StudentBase delete = m.getStudentById(id.GetValueOrDefault());

            if (delete == null)
            {
                return RedirectToAction("index");
            }
            else
            {
                return View(delete);
            }
        }

        // POST: /Student/Delete/5
        [HttpPost]
        [Authorize(Roles = "Admin, Coordinator")]// Set the authorized roles to access
        public ActionResult Delete(int id)
        {
            //this function will grant Authorized user to an use function of delete
            // this function are same from LAB work.

            if (m.DeleteStudentById(id))
            {
                // if delete was successful will send this message

                TempData["statusMessage"] = "This student was deleted.";
            }
            else
            {
                // if delete was NOT successful will send this message
                TempData["statusMessage"] = "Unable to delete this student.";
            }
            return RedirectToAction("details", new { id = id });
        }

        // GET: /Student/Edit/5
        [Authorize(Roles = "Admin, Coordinator")]// Set the authorized roles to access
        public ActionResult Edit(int id)
        {
            // this function will grant Authorized user to use function of Edit student
            // this function are same from LAB work.

            StudentBase fetchedStudent = m.getStudentById(id);

            if (fetchedStudent == null)
            {
                return RedirectToAction("index");
            }
            else
            {
                return View(fetchedStudent);
            }
        }



        // POST: /Student/Edit/5
        [HttpPost]
        [Authorize(Roles = "Admin, Coordinator")]// Set the authorized roles to access
        public ActionResult Edit(int id, StudentBase newItem)
        {
            // this function will grant Authorized user to use function of Edit student
            if (ModelState.IsValid & id == newItem.Id)
            {
                StudentBase editedItem = m.EditStudent(newItem);

                if (editedItem == null)
                {
                    //  there was ERROR occured during edit
                    return View(newItem);
                }
                else
                {
                   // The Edit was successful, Student info has been edited.
                    TempData["statusMessage"] = "Edits have been saved.";
                    return RedirectToAction("details", new { id = editedItem.Id });
                }
            }
            else
            {
               
                return View(newItem);
            }
        }
        

	}
}
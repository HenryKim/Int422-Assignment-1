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
    public class ProgramController : Controller
    {
        // Similar codes to Student Controller different variabless
        ProgramManager m = new ProgramManager();
        

        [Authorize(Roles = "Admin, Coordinator")]
        public ActionResult Index()
        {
            return View(m.getAllPrograms());
        }


        [Authorize(Roles = "Admin, Coordinator")]
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [Authorize(Roles = "Admin, Coordinator")]
        public ActionResult Create(AddProgram newItem)
        {
            if (ModelState.IsValid)
            {
                m.createProgram(newItem);
                return RedirectToAction("index");
            }
            else
            {
                return View(newItem);
            }
        }

        [Authorize(Roles = "Admin, Coordinator")]
        public ActionResult Details(int id)
        {
            var fetchedObject = m.GetProgramById(id);

            if (fetchedObject == null)
            {
                return RedirectToAction("index");
            }
            else
            {
                return View(fetchedObject);
            }
        }



        [Authorize(Roles = "Admin, Coordinator")]
        public ActionResult Delete(int? id)
        {
            ProgramBase itemToDelete = m.GetProgramById(id.GetValueOrDefault());

            if (itemToDelete == null)
            {
                return RedirectToAction("index");
            }
            else
            {
                return View(itemToDelete);
            }
        }

         
        [HttpPost]
        [Authorize(Roles = "Admin, Coordinator")]
        public ActionResult Delete(int id)
        {

            if (m.DeleteProgramById(id))
            {

                TempData["statusMessage"] = "This program was deleted.";
            }
            else
            {

                TempData["statusMessage"] = "Unable to delete this program.";
            }
            return RedirectToAction("details", new { id = id });
        }



        [Authorize(Roles = "Admin, Coordinator")]
        public ActionResult Edit(int id)
        {
            ProgramBase fetchedObject = m.GetProgramById(id);

            if (fetchedObject == null)
            {
                return RedirectToAction("index");
            }
            else
            {
                return View(fetchedObject);
            }
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Coordinator")]
        public ActionResult Edit(int id, ProgramBase newItem)
        {
            if (ModelState.IsValid & id == newItem.Id)
            {
                ProgramBase editedItem = m.EditProgram(newItem);

                if (editedItem == null)
                {
                    return View(newItem);
                }
                else
                {
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
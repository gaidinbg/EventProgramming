using AssignmentManager.DataAccess;
using AssignmentManager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AssignmentManager.Controllers
{
    public class AssignmentController : Controller
    {
        //
        // GET: /Assignment/
        public ActionResult Index()
        {
            ViewBag.Title = "Assignments'List with Title";
            List<Assignment> assignments = new List<Assignment>();
            AssignmentRepository assignmentRepository = new AssignmentRepository();
            assignments.AddRange(assignmentRepository.GetAll());
            return View(assignments);
          
        }
        [HttpGet]
        public ActionResult Create()
        {

            return View();

        }

        [HttpPost]
        public ActionResult Create(Assignment entity)
        {
            entity.CreatedAt = DateTime.Now;
            entity.UpdatedAt = DateTime.Now;
            entity.isDone = false;


            var assignmentReposotory = new AssignmentRepository();
            assignmentReposotory.Insert(entity);
                //ctrl + shift + space - pokazva kakvi parametri iziskwa daden metod
            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult Update(int id)
        {

            var assignmentRepository = new AssignmentRepository();
            Assignment entity = assignmentRepository.GetbyId(id);
            return View(entity);
        }
         [HttpPost]
        public ActionResult Update(Assignment entity)
        {
            var assignmentRepository = new AssignmentRepository();
            entity.UpdatedAt = DateTime.Now;
            assignmentRepository.Update(entity);
            return RedirectToAction("Index");
        }

         public ActionResult Delete (int id)
         {
             var assignmentRepository = new AssignmentRepository();
             Assignment entity = assignmentRepository.GetbyId(id);
             assignmentRepository.Delete(entity);

             return RedirectToAction("Index");


         }
       

        // ctrl + r+r - mozhe da se editva imeto na promenliva.,.. iz/za celiq proekt.
	}
}
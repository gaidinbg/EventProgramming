using AssignmentManager.DataAccess;
using AssignmentManager.Entities;
using AssignmentManager.Models;
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
            AssignmentListViewModel model = new AssignmentListViewModel();

           model.Title = "Assignments'List with Title";

            AssignmentRepository assignmentRepository = new AssignmentRepository();
            List<Assignment> assignments = new List<Assignment>();
            assignments.AddRange(assignmentRepository.GetAll());


            foreach (var entity in assignments)
            {
                var assignmentModel = new AssignmentViewModel()
                {
                    Id = entity.Id,
                    Title = entity.Title,
                    Description = entity.Description,
                    CreatedAt = entity.CreatedAt,
                    UpdatedAt = entity.UpdatedAt,
                    isDone = entity.isDone

                };
                model.Assignments.Add(assignmentModel);
            }


            return View(model);
          
        }
        [HttpGet]
        public ActionResult Create()
        {

            return View();

        }

        [HttpPost]
        public ActionResult Create(AssignmentViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return View();

            }
            var entity = new Assignment();
            entity.CreatedAt = DateTime.Now;
            entity.UpdatedAt = DateTime.Now;
            entity.isDone = false;
            entity.Title = model.Title;
            entity.Description = model.Description;

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

            var model = new AssignmentViewModel()
            {
                Id = entity.Id,
                Title = entity.Title,
                Description = entity.Description,
                UpdatedAt = entity.UpdatedAt,
                CreatedAt = entity.CreatedAt,
                isDone = entity.isDone

            };
            return View(model);
        }
         [HttpPost]
        public ActionResult Update(AssignmentViewModel model)
        {
             if(!ModelState.IsValid)
             {
                 return View();
             }
            var entity = new Assignment();
                entity.Id = model.Id;
                entity.Title = model.Title;
                entity.Description = model.Description;
                entity.CreatedAt = DateTime.Now;
                entity.UpdatedAt = DateTime.Now;
                entity.isDone = entity.isDone;

             var assignmentRepository = new AssignmentRepository();
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
using EmployeeManagement.Data_Access;
using EmployeeManagement.Entities;
using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeManagement.Controllers
{
    public class AssignmentsController : Controller
    {
        //
        // GET: /Assignments/
        public ActionResult Index(int id)
        {

            var assignmentRepository = new AssignmentRepository();
            List<Assignment> assignments = new List<Assignment>();

            assignments.AddRange(assignmentRepository.GetAll(assignment => assignment.EmployeeId == id));

            var firstAssignment = assignments.FirstOrDefault();
            var employeeRpository = new EmployeeRepository();

            ViewBag.EmployeeName = employeeRpository.GetbyId(id).FirstName + "" + employeeRpository.GetbyId(id).LastName;
            ViewBag.EmployeeId = id;

            return View(assignments);
        }

        [HttpGet]
        public ActionResult Create(int id)
        {
            var model = new AssignmentViewModel()
            {
                EmployeeId = id,
                Deadline = DateTime.Now,

            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(AssignmentViewModel model)
        {

            var entity = new Assignment();
            entity.EmployeeId = model.EmployeeId;
            entity.Title = model.Title;
            entity.Description = model.Description;
            entity.Deadline = model.Deadline;
         

            var assignmentRepository = new AssignmentRepository();
            assignmentRepository.Insert(entity);

            return RedirectToAction("Index/" + entity.EmployeeId);

        }
        [HttpGet]
        public ActionResult Update(int id)
        {
            var assignmentRepository = new AssignmentRepository();
            var entity = assignmentRepository.GetbyId(id);


            return View(entity);
        }

        [HttpPost]
        public ActionResult Update(Assignment entity)
        {

            var assignmentRepository = new AssignmentRepository();
            assignmentRepository.Update(entity);

            return RedirectToAction("Index/" + entity.EmployeeId);
        }

        public ActionResult Delete(int id)
        {
            var assignmentRepository = new AssignmentRepository();
            var entity = assignmentRepository.GetbyId(id);

            assignmentRepository.Delete(entity);
            return RedirectToAction("Index/" + entity.EmployeeId);
        }

        



	}
}
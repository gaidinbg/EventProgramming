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
    public class EmployeesController : Controller
    {
        //
        // GET: /Employees/
        [HttpGet]
        public ActionResult Index()
        {
            EmployeeListViewModel model = new EmployeeListViewModel();

            model.Names = "List of all users";

            EmployeeRepository employeeRepository = new EmployeeRepository();
            List<Employee> employees = new List<Employee>();
            employees.AddRange(employeeRepository.GetAll());


            foreach (var entity in employees)
            {
                var employeeModel = new EmployeeViewModel()
                {
                    Id = entity.Id,
                    FirstName = entity.FirstName,
                    LastName = entity.LastName,
                    Phone = entity.Phone,
                    CreatedAt = entity.CreatedAt,
                    UpdatedAt = entity.UpdatedAt
                    

                };
                model.Employees.Add(employeeModel);
            }


            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {

            return View();

        }

        [HttpPost]
        public ActionResult Create(EmployeeViewModel model)
        {

            var entity = new Employee();
            entity.FirstName = model.FirstName;
            entity.LastName = model.LastName;
            entity.Phone = model.Phone;
            entity.CreatedAt = DateTime.Now;
            entity.UpdatedAt = DateTime.Now;
            

            var employeeReposotory = new EmployeeRepository();
            employeeReposotory.Insert(entity);
            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult Update(int id)
        {

            var employeeRepository = new EmployeeRepository();
            Employee entity = employeeRepository.GetbyId(id);

            var model = new EmployeeViewModel()
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Phone = entity.Phone,
                UpdatedAt = entity.UpdatedAt,
                CreatedAt = entity.CreatedAt,

            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Update(EmployeeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var entity = new Employee();
            entity.Id = model.Id;
            entity.FirstName = model.FirstName;
            entity.LastName = model.LastName;
            entity.Phone = model.Phone;
            entity.CreatedAt = DateTime.Now;
            entity.UpdatedAt = DateTime.Now;
         

            var employeeRepository = new EmployeeRepository();
            employeeRepository.Update(entity);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var employeeRepository = new EmployeeRepository();
            Employee entity = employeeRepository.GetbyId(id);
            employeeRepository.Delete(entity);

            return RedirectToAction("Index");


        }

	}
}
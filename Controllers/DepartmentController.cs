using LMS.Context;
using LMS.Filters;
using LMS.Models;
using LMS.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LMS.Controllers
{
    [Authorize]
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository repository;

        public DepartmentController(IDepartmentRepository repository)
        {
            this.repository = repository;
        }

        public IActionResult Index()
        {
            return RedirectToAction("GetAll");
        }

        [AddResultInfo]
        public IActionResult GetAll()
        {
            var departments = repository.GetAll();

            return View("GetAll", departments);
        }

        public IActionResult GetById(int id)
        {
            var department = repository.GetDepartmentWithRelations(id);
            if (department == null)
            {
                return Content("Department not found.");
            }
            return View("GetById", department);
        }

        public IActionResult GetByName(string name)
        {
            var department = repository.GetDepartmentByName(name);
            if (department == null)
            {
                return Content("Department not found.");
            }
            return View("GetById", department);
        }

        [HttpGet]
        public IActionResult Add()
        {
            Department department = new Department();
            return View("Add", department);
        }

        [HttpPost]
        [DepartmentLocation]
        public IActionResult Add(Department department)
        {
            if (ModelState.IsValid)
            {
                repository.Add(department);
                return RedirectToAction("Index");
            }
            return View("Add", department);
        }

        public ActionResult Delete(int id)
        {
            repository.Delete(id);
            return RedirectToAction("GetAll");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var department = repository.GetById(id);
            if (department != null)
            {
                return View("Edit", department);
            }
            return Content("Department Not Found");
        }

        [HttpPost]
        public ActionResult Edit(Department department)
        {
            if (ModelState.IsValid)
            {
                repository.Update(department);
                return RedirectToAction("GetAll");
            }
            return View("Edit", department);
        }
    }
}
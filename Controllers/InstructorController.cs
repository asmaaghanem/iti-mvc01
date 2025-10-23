using LMS.Context;
using LMS.Models;
using LMS.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LMS.Controllers
{
    [Authorize]
    public class InstructorController : Controller
    {
        private readonly IInstructorRepository repository;
        private readonly IDepartmentRepository department;

        public InstructorController(IInstructorRepository repository, IDepartmentRepository department)
        {
            this.repository = repository;
            this.department = department;
        }

        public IActionResult Index()
        {
            return RedirectToAction("GetAll");
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var instructors = repository.GetAll();
            return View("GetAll", instructors);
        }

        [HttpGet]
        public IActionResult GetById(int Id)
        {
            var instructor = repository.GetInstructorWithRelations(Id);

            if (instructor == null)
            {
                return Content("No instructor with this Id");
            }

            return View("GetById", instructor);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewData["DeptList"] = department.GetAll();
            Instructor instructor = new Instructor();
            return View("Add", instructor);
        }

        [HttpPost]
        public IActionResult Add(Instructor instructor)
        {
            if (ModelState.IsValid)
            {
                repository.Add(instructor);
                return RedirectToAction("GetAll");
            }
            ViewData["DeptList"] = department.GetAll();
            return View("Add", instructor);
        }

        public ActionResult Delete(int id)
        {
            repository.Delete(id);
            return RedirectToAction("GetAll");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var instructor = repository.GetById(id);
            ViewData["DeptList"] = department.GetAll();
            if (instructor != null)
            {
                return View("Edit", instructor);
            }
            return Content("Student Not Found");
        }

        [HttpPost]
        public ActionResult Edit(Instructor instructor)
        {
            if (ModelState.IsValid)
            {
                repository.Update(instructor);
                return RedirectToAction("GetAll");
            }
            ViewData["DeptList"] = department.GetAll();
            return View("Edit", instructor);
        }
    }
}
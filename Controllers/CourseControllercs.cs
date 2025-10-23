using LMS.Context;
using LMS.Models;
using LMS.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LMS.Controllers
{
    [Authorize]
    public class CourseController : Controller
    {
        private readonly ICourseRepository repository;

        public CourseController(ICourseRepository repository)
        {
            this.repository = repository;
        }

        public IActionResult Index()
        {
            return RedirectToAction("GetAll");
        }

        public IActionResult GetAll()
        {
            var courses = repository.GetAll();
            return View("GetAll", courses);
        }

        public IActionResult GetById(int id)
        {
            var course = repository.GetCourseWithRelations(id);
            if (course == null)
            {
                return Content("Department not found.");
            }
            return View("GetById", course);
        }

        [HttpGet]
        public IActionResult Add()
        {
            Course course = new Course();
            return View("Add", course);
        }

        [HttpPost]
        public IActionResult Add(Course course)
        {
            if (ModelState.IsValid)
            {
                repository.Add(course);
                return RedirectToAction("Index");
            }
            return View("Add", course);
        }

        public ActionResult Delete(int id)
        {
            repository.Delete(id);
            return RedirectToAction("GetAll");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var course = repository.GetById(id);
            if (course != null)
            {
                return View("Edit", course);
            }
            return Content("Department Not Found");
        }

        [HttpPost]
        public ActionResult Edit(Course course)
        {
            if (ModelState.IsValid)
            {
                repository.Update(course);
                return RedirectToAction("GetAll");
            }
            return View("Edit", course);
        }
    }
}
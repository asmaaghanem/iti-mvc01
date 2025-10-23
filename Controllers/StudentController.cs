using LMS.Context;
using LMS.Filters;
using LMS.Models;
using LMS.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LMS.Controllers
{
    [Authorize]
    public class StudentController : Controller
    {
        private readonly IStudentRepository repository;
        private readonly IDepartmentRepository department;

        public StudentController(IStudentRepository repository, IDepartmentRepository department)
        {
            this.repository = repository;
            this.department = department;
        }

        public IActionResult Index()
        {
            HttpContext.Session.SetString("UserRole", "sss");

            return RedirectToAction("GetAll");
        }

        [ModeResourceFilter]
        public IActionResult GetAll()
        {
            var students = repository.GetAll();
            return View("GetAll", students);
        }

        public IActionResult GetBySSN(int SSN)
        {
            var student = repository.GetStudentWithRelationsbySSn(SSN);
            if (student == null)
            {
                return Content("No Student with this SSN");
            }

            return View("GetBySSN", student);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewData["DeptList"] = department.GetAll();
            Student student = new Student();
            return View("Add", student);
        }

        [HttpPost]
        public IActionResult Add(Student student)
        {
            if (ModelState.IsValid)
            {
                repository.Add(student);
                return RedirectToAction("GetAll");
            }
            ViewData["DeptList"] = department.GetAll();
            return View("Add", student);
        }

        [AdminOnly]
        public ActionResult Delete(int SSN)
        {
            repository.Delete(SSN);
            return RedirectToAction("GetAll");
        }

        [HttpGet]
        public ActionResult Edit(int SSN)
        {
            var student = repository.GetById(SSN);
            ViewData["DeptList"] = department.GetAll();
            if (student != null)
            {
                return View("Edit", student);
            }
            return Content("Student Not Found");
        }

        [HttpPost]
        public ActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                repository.Update(student);
                return RedirectToAction("GetAll");
            }
            ViewData["DeptList"] = department.GetAll();
            return View("Edit", student);
        }
    }
}
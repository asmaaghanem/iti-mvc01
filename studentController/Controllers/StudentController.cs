using Microsoft.AspNetCore.Mvc;
using studentController.Context;

namespace studentController.Controllers
{
    public class StudentController : Controller
    {
        StudentContext db = new StudentContext();

        public IActionResult getAll()
        {
            var depts = db.Students.ToList();
            return View("getAll",depts); //model
        }

        public IActionResult getById(int id)
        {
            var dept = db.Students.Find(id);
            if (dept == null)
                return NotFound();
            return View("getById",dept); //model
        }






















        //public ContentResult test()
        //{
        //    //ContentResult res = new ContentResult();
        //    //res.Content = "hello from student";
        //    return Content("hello from student");
        //}
        //public JsonResult testJson()
        //{             //ContentResult res = new ContentResult();
        //    //res.Content = "hello from student";
        //    return Json(new { id = 1, name = "ahmed" });
        //}

        //public IActionResult testView()
        //{
        //    //ContentResult res = new ContentResult();
        //    //res.Content = "hello from student";
        //    return View(test);
        //}
    }
}

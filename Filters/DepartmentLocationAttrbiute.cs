using LMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace LMS.Filters
{
    public class DepartmentLocationAttribute : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ActionArguments["department"] is Department department)
            {
                string loc = department.Location.Trim().ToLower();
                if (loc != "usa" && loc != "eg")
                {
                    ((Controller)context.Controller).ModelState.AddModelError("Location", "Location must be either 'USA' or 'EG'");
                    context.Result = ((Controller)context.Controller).View("Add", department);
                }
            }
        }
    }
}
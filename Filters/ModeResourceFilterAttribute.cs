using Microsoft.AspNetCore.Mvc.Filters;

namespace LMS.Filters
{
    public class ModeResourceFilterAttribute : Attribute, IResourceFilter
    {
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            Console.WriteLine("Resource Filter: Request finished!");
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            Console.WriteLine("Resource Filter: Request starting");
        }
    }
}
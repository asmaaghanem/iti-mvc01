using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace LMS.Filters
{
    public class HandelErrorAttribute : Attribute, IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            string viewName = "Error";

            if (context.Exception is UnauthorizedAccessException)
            {
                viewName = "UnauthorizedError";
            }
            else if (context.Exception is KeyNotFoundException || context.Exception is FileNotFoundException)
            {
                viewName = "PageNotFoundError";
            }

            ViewResult viewResult = new ViewResult();
            viewResult.ViewName = $"~/Views/Shared/Errors/{viewName}.cshtml";

            context.Result = viewResult;
        }
    }
}
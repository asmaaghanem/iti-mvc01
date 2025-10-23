using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace LMS.Filters
{
    public class AdminOnlyAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var userRole = context.HttpContext.Session.GetString("UserRole");
            if (string.IsNullOrEmpty(userRole) || userRole != "Admin")
            {
                context.Result = new RedirectToActionResult("Error", "Home", null);
            }
        }
    }
}
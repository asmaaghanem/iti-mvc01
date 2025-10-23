using LMS.Models;
using LMS.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LMS.Controllers
{
    public class RoleController : Controller
    {
        private readonly UserManager<ApplicationUser> mazenManager;
        private readonly RoleManager<IdentityRole> roleManger;

        public RoleController(UserManager<ApplicationUser> mazenManager, RoleManager<IdentityRole> roleManager)
        {
            this.mazenManager = mazenManager;
            this.roleManger = roleManager;
        }

        [HttpGet]
        public IActionResult AddRole()
        {
            return View("AddRole");
        }

        [HttpPost]
        public async Task<IActionResult> AddRole(RoleViewModel roleViewModel)
        {
            if (ModelState.IsValid)
            {
                IdentityRole role = new IdentityRole();
                role.Name = roleViewModel.RoleName;
                IdentityResult result = await roleManger.CreateAsync(role);
                if (result.Succeeded == true)
                {
                    ViewBag.sucess = true;
                    return RedirectToAction("index", controllerName: "Home");
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            return View("AddRole", roleViewModel);
        }
    }
}
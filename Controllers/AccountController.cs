using LMS.Models;
using LMS.ViewModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LMS.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> mazenManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(UserManager<ApplicationUser> mazenManager, SignInManager<ApplicationUser> signInManager)
        {
            this.mazenManager = mazenManager;
            this.signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult Register()
        {
            RegisterUserViewModel registerUserViewModel = new RegisterUserViewModel();

            return View("Register", registerUserViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterUserViewModel registerUserViewModel)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser applicationUser = new ApplicationUser()
                {
                    UserName = registerUserViewModel.UserName,
                    Email = registerUserViewModel.Email
                };

                IdentityResult result = await mazenManager.CreateAsync(applicationUser, registerUserViewModel.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Login");
                }
                else
                {
                    foreach (var err in result.Errors)
                    {
                        ModelState.AddModelError("", err.Description);
                    }
                }
            }

            return View("Register", registerUserViewModel);
        }

        [HttpGet]
        public IActionResult Login()
        {
            LoginUserViewModel loginUserViewModel = new LoginUserViewModel();
            return View("Login", loginUserViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginUserViewModel loginUser)
        {
            if (ModelState.IsValid)
            {
                var user = await mazenManager.FindByNameAsync(loginUser.UserName);
                if (user != null)
                {
                    if (await mazenManager.CheckPasswordAsync(user, loginUser.Password))
                    {
                        await signInManager.SignInAsync(user, loginUser.RememberMe);
                        return RedirectToAction("Index", "Home");
                    }
                }
            }

            return View();
        }

        [HttpGet]
        [Authorize]
        public new async Task<IActionResult> SignOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }

        [HttpGet]
        public async Task<IActionResult> LoginWithGoogle()
        {
            await HttpContext.ChallengeAsync(GoogleDefaults.AuthenticationScheme,
            new AuthenticationProperties
            {
                RedirectUri = Url.Action("GoogleResponse")
            });
            return new EmptyResult();
        }

        public async Task<IActionResult> GoogleResponse()
        {
            var result = await HttpContext.AuthenticateAsync(GoogleDefaults.AuthenticationScheme);

            var email = result.Principal.FindFirstValue(ClaimTypes.Email);
            var name = result.Principal.FindFirstValue(ClaimTypes.Name);

            var user = await mazenManager.FindByEmailAsync(email);
            if (user == null)
            {
                user = new ApplicationUser { UserName = name, Email = email };
                await mazenManager.CreateAsync(user);
            }

            await signInManager.SignInAsync(user, false);

            return RedirectToAction("Index", "Home");
        }
    }
}
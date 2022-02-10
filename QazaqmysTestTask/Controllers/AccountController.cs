using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QazaqmysTestTask.Controllers.Authorization;
using QazaqmysTestTask.Controllers.Authorization.Login;
using QazaqmysTestTask.Controllers.Authorization.Registration;
using QazaqmysTestTask.Models.Authorization;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace QazaqmysTestTask.Controllers
{
    public class AccountController : Controller
    {
        [Authorized]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Authorized]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginModel model)
        {
            if(ModelState.IsValid)
            {
                if(LoginHandler.AreCredentialsCorrect(model, HttpContext).Result is true)
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            ModelState.AddModelError("", "Enter your credentials correct");
            return View();
        }

        [HttpGet]
        [Authorized]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(RegistrationModel model)
        {
            if (ModelState.IsValid)
            {
                if (RegistrationHandler.Registrable(model, HttpContext).Result is true)
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            ModelState.AddModelError("", "Enter your credentials correct");

            return View();
        }


        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }
    }
}

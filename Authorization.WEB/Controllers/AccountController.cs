using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Authorization.Core.Interfaces;
using Authorization.DAL.Model;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Authorization.Core.Infrastructure;
using Authorization.Core.ViewModels;


namespace Authorization.WEB.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUsersRepository<User> _usersRepository;
        private readonly IConfiguration _configuration;

        public AccountController(IUsersRepository<User> usersRepository, IConfiguration configuration)
        {
            this._usersRepository = usersRepository;
            this._configuration = configuration;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            if (ModelState.IsValid)
            {
                string salt = _configuration.GetValue<string>("Salt");
                string hashedPassword = Helpers.GetPasswordHash(model.Password, salt);
                var user = _usersRepository.GetUser(model.Username, hashedPassword);
                if (user != null)
                {
                    await SignIn(model.Username, model.RememberMe);

                    if (IsAjaxRequest)
                        return Json(new { Success = true });

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Incorrect username or password");

                    if (IsAjaxRequest)
                        return Json(new { Success = false, Errors = ModelStateErrors });

                    return View();
                }
            }
            else
            {
                if (IsAjaxRequest)
                    return Json(new { Success = false, Errors = ModelStateErrors });

                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> SignOut()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }

        // Detects ajax request
        private bool IsAjaxRequest => Request.Headers["X-Requested-With"] == "XMLHttpRequest";

        // Modelstate errors
        private List<string> ModelStateErrors => ModelState.Values.SelectMany(m => m.Errors)
                         .Select(e => e.ErrorMessage)
                         .ToList();

        //Save authentication cookie
        public async Task SignIn(string username, bool rememberMe)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, username)
            };
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authenticationProperties = new AuthenticationProperties()
            {
                IsPersistent = rememberMe,
                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10)
            };
            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authenticationProperties);
        }
    }
}
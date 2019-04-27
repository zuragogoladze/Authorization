using Authorization.Core.Infrastructure;
using Authorization.Core.Interfaces;
using Authorization.Core.ViewModels;
using Authorization.DAL.Model;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WEB.Controllers
{
    public class AccountController : Controller
    {
        private readonly IPersonsRepository<Person> _personsRepository;
        private readonly IConfiguration _configuration;

        public AccountController(IPersonsRepository<Person> personsRepository, IConfiguration configuration)
        {
            this._personsRepository = personsRepository;
            this._configuration = configuration;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                string salt = _configuration.GetValue<string>("Salt");
                string hashedPassword = Helpers.GetPasswordHash(model.Password, salt);
                var user = _personsRepository.GetPerson(model.Username, hashedPassword);
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

        private List<string> ModelStateErrors => ModelState.Values.SelectMany(m => m.Errors)
                                 .Select(e => e.ErrorMessage)
                                 .ToList();
        private bool IsAjaxRequest => Request.Headers["X-Requested-With"] == "XMLHttpRequest";

        private async Task SignIn(string username, bool rememberMe)
        {
            var claims = new List<Claim>
            {
               new Claim(ClaimTypes.Name, username)
            };
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties
            {
                IsPersistent = rememberMe,
                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10)
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);
        }
    }
}

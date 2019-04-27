using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using WEB.Models;

namespace WEB.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var authenticate = await HttpContext.AuthenticateAsync();

            if (!authenticate.Succeeded)
            {
                return RedirectToAction("Login", "Account");
            }

            ViewBag.Username = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value;

            return View();
        }
    }
}

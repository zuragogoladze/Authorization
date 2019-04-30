using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace Authorization.WEB.Controllers
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

            ViewBag.Username = HttpContext.User.Claims.FirstOrDefault(u => u.Type == ClaimTypes.Name)?.Value;
            return View();
        }
    }
}

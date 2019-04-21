using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Threading.Tasks;

namespace Authorization.DAL.Model
{
    public class SampleData
    {
        public static void SeedUsers(UserManager<IdentityUser> userManager)
        {
            if (userManager.FindByEmailAsync("gogoladze.zura@gmail.com").Result == null)
            {
                IdentityUser user = new IdentityUser
                {
                    UserName = "gogoladze.zura@gmail.com",
                    Email = "gogoladze.zura@gmail.com",
                    EmailConfirmed = true
                };

                IdentityResult result = userManager.CreateAsync(user, "Strongpassw0rd!").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            }
        }
    }
}

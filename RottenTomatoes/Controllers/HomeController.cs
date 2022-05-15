using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RottenTomatoes.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace RottenTomatoes.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private RoleManager<IdentityRole> roleManager;
        private UserManager<AppUser> userManager;
        public HomeController(ILogger<HomeController> logger, RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager)
        {
            _logger = logger;
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            if (await roleManager.FindByNameAsync("Tomatoe") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("Tomatoe"));
            }
            if (await roleManager.FindByNameAsync("Administrator") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("Administrator"));
            }
            if (await userManager.FindByNameAsync("VladSav") == null)
            {
                await userManager.CreateAsync(new AppUser { UserName = "VladSav",
                Email = "vladsav@gmail.com"}, "123vladsav");
                await userManager.AddToRoleAsync(userManager.FindByNameAsync("VladSav").Result
                    , "Administrator");
            }

            //if (HttpContext.User.IsInRole("Artist"))
            //    return RedirectToAction("Index", "A");
            //else if (HttpContext.User.IsInRole("Listener"))
            //    return RedirectToAction("Index", "Listener");
           
           // return View("~/Views/Song/RecentlyAdded.cshtml");
            return View();
        }

    }
}

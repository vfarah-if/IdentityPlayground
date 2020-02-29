using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public HomeController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult Secret()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync(string username, string password)
        {
            var user = await userManager.FindByNameAsync(username);
            if (user != null)
            {
                var result = await signInManager.PasswordSignInAsync(user, password, true, false);
                if (!result.Succeeded)
                {
                    return RedirectToAction("Login");
                }
            }
            return RedirectToAction("Index");

        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterAsync(string username, string password)
        {
            var user = new IdentityUser
            {
                UserName = username
            };
            var result = await userManager.CreateAsync(user, password);
            if(result.Succeeded)
            {
                return await LoginAsync(username, password);
            }
            return RedirectToAction("Index");
        }
    }
}
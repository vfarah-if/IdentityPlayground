using System;
using Identity.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Controllers
{
    public class HomeController : IdentityController
    {

        public HomeController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
            : base(userManager, signInManager)
        {            
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
    }
}
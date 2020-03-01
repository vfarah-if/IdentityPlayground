using System;
using System.Threading.Tasks;
using Identity.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Controllers
{
    public class LoginController : IdentityController
    {
        public LoginController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager) 
            : base(userManager, signInManager)
        {
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpPost, Route("login")]
        public async Task<IActionResult> LoginAsync(string username, string password)
        {
            var user = await ManageUser.FindByNameAsync(username);
            if (user != null)
            {
                var result = await ManageSignIn.PasswordSignInAsync(user, password, true, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return RedirectToAction("Index");
        }

    }
}
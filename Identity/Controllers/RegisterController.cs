using System;
using System.Threading.Tasks;
using Identity.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace Identity.Controllers
{
    public class RegisterController : IdentityController
    {
        public RegisterController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager) 
            : base(userManager, signInManager)
        {
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost, Route("register")]
        public async Task<IActionResult> RegisterAsync(string username, string password)
        {
            var user = new IdentityUser
            {
                UserName = username
            };
            var result = await ManageUser.CreateAsync(user, password);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Login");
            }
            return RedirectToAction("Index");
        }

    }
}

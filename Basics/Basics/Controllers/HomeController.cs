using System;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Basics.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult Secret()
        {
            return View();
        }

        [Authorize(Policy = "Claim.DOB")]
        public IActionResult SecretPolicy()
        {
            return View("Secret");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult SecretRole()
        {
            return View("Secret");
        }

        public IActionResult Authenticate()
        {
            var grandmaIdentity = CreateGrandmaClaims();
            var licensingIdentity = CreateLicenseClaims();

            var userPrinciple = new ClaimsPrincipal(new[] { grandmaIdentity, licensingIdentity });
            HttpContext.SignInAsync(userPrinciple);

            return RedirectToAction("Index");
        }

        private static ClaimsIdentity CreateGrandmaClaims()
        {
            var grandmaClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, "Bob"),
                new Claim(ClaimTypes.Email, "bob@mail.com"),
                new Claim(ClaimTypes.DateOfBirth, "11/04/2000"),
                new Claim(ClaimTypes.Role, "Admin"),
                new Claim("Grandma says", "Good kid, honest")
            };
            return new ClaimsIdentity(grandmaClaims, "Grandma Identity");
        }

        private static ClaimsIdentity CreateLicenseClaims()
        {
            var licenseClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, "Bob K Foo"),
                new Claim("License", "MotorCycle 50 CC"),
            };
            return new ClaimsIdentity(licenseClaims, "Government Licensing Department");
        }
    }
}
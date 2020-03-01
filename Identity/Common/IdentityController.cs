using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Identity.Common
{
    public class IdentityController : Controller
    {
        protected IdentityController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            ManageUser = userManager;
            ManageSignIn = signInManager;
        }

        public UserManager<IdentityUser> ManageUser { get; }
        public SignInManager<IdentityUser> ManageSignIn { get; }
    }
}

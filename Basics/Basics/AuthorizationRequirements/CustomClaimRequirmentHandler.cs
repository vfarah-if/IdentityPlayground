using Microsoft.AspNetCore.Authorization;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Basics.AuthorizationRequirements
{
    public class CustomClaimRequirmentHandler : AuthorizationHandler<CustomClaimRequirement>
    {
        public CustomClaimRequirmentHandler()
        {
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, CustomClaimRequirement requirement)
        {
            var hasClaim = context.User.Claims.Any(x => x.Type == requirement.ClaimType);
            if (hasClaim)
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}

using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Tech_news.Authorization
{
    public class SameUserRequirement : IAuthorizationRequirement { }

    public class SameUserHandler : AuthorizationHandler<SameUserRequirement, int>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, SameUserRequirement requirement, int userId)
        {
            if (context.User.HasClaim(c => c.Type == ClaimTypes.NameIdentifier))
            {
                var loggedInUserId = int.Parse(context.User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value);

                if (loggedInUserId == userId || context.User.IsInRole("Admin"))
                {
                    context.Succeed(requirement);
                }
            }

            return Task.CompletedTask;
        }
    }
}

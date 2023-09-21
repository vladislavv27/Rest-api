using Microsoft.AspNetCore.Authorization;

namespace Bbit2taks.Policy
{
    public class ManagerOrResidentAuthorizationHandler : AuthorizationHandler<ManagerOrResidentRequirement>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ManagerOrResidentAuthorizationHandler(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ManagerOrResidentRequirement requirement)
        {
            if (context.User.IsInRole("Manager"))
            {
                context.Succeed(requirement);
                return Task.CompletedTask;
            }

            //var resident = context.Resource as Resident;

            if (int.Parse(_httpContextAccessor.HttpContext.Request.RouteValues["id"] as string) == JwtHelper.GetResidentId(_httpContextAccessor.HttpContext))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}

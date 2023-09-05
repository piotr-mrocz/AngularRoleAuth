using Microsoft.AspNetCore.Authorization;

namespace AngularRoleAuth_Backend.Auth;

public class PermissionRequirement : IAuthorizationRequirement
{
    public string Permission { get; private set; } = null!;

    public PermissionRequirement(string permission)
    {
        Permission = permission;
    }
}


internal class PermissionAuthorizationHandler : AuthorizationHandler<PermissionRequirement>
{
    private IConfiguration Configuration { get; }

    public PermissionAuthorizationHandler(IConfiguration configuration)
    {
        Configuration = configuration;
    }

#pragma warning disable CS1998
    protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
    {
        if (context.User == null)
            return;

        var permissionss = context.User.Claims
            .Where(x =>
                        x.Type == "Permission" &&
                        x.Value == requirement.Permission &&
                        x.Issuer == Configuration["JwtIssuer"]);

        if (permissionss == null || !permissionss.Any())
            return;

        context.Succeed(requirement);
        return;
    }
}
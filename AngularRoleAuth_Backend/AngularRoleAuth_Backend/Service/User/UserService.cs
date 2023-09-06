using System.Security.Claims;

namespace AngularRoleAuth_Backend.Service.User;

public class UserService : IUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UserService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public string GetMyName()
    {
        if (_httpContextAccessor.HttpContext == null)
            return string.Empty;

        return _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name) ?? string.Empty;
    }
}

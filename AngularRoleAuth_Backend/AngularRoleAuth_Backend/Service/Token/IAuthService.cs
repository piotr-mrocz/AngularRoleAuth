namespace AngularRoleAuth_Backend.Service.Token;

public interface IAuthService
{
    string GenerateToken(Entities.User user);
}
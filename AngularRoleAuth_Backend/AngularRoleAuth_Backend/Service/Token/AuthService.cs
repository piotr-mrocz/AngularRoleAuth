using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AngularRoleAuth_Backend.Service.Token;

#pragma warning disable CS8604
public sealed class AuthService : IAuthService
{
    private IConfiguration Configuration { get; }

    public AuthService(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public string GenerateToken(Entities.User user)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Name),
            new Claim(ClaimTypes.Role, user.Role.ToString()),
        };

        var token = new JwtSecurityToken
        (
            issuer: Configuration["JwtIssuer"],
            audience: Configuration["JwtIssuer"],
            claims: claims,
            expires: DateTime.UtcNow.AddDays(60),
            notBefore: DateTime.UtcNow,
            signingCredentials: new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JwtKey"])),
                SecurityAlgorithms.HmacSha256)
        );

        var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
        return jwtToken;
    }
}

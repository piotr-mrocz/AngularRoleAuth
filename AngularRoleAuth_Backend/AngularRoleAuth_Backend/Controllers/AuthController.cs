using AngularRoleAuth_Backend.Service.DataBase;
using Microsoft.AspNetCore.Mvc;

namespace AngularRoleAuth_Backend.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class AuthController : ControllerBase
{
    private readonly IDataBaseService _dbContext;

    public AuthController(IDataBaseService dbContext)
    {
        _dbContext = dbContext;
    }
}
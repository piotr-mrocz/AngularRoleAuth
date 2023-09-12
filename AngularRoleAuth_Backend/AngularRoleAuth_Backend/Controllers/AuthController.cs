using AngularRoleAuth_Backend.Dtos;
using AngularRoleAuth_Backend.Service.DataBase;
using AngularRoleAuth_Backend.Service.Token;
using AngularRoleAuth_Backend.Service.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AngularRoleAuth_Backend.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class AuthController : ControllerBase
{
    private readonly IDataBaseService _dbContext;
    private readonly IAuthService _authService;
    private readonly IUserService _userService;

    public AuthController(
        IDataBaseService dbContext,
        IAuthService authService,
        IUserService userService)
    {
        _dbContext = dbContext;
        _authService = authService;
        _userService = userService;
    }

    [HttpPost]
    public IActionResult Login(UserDto userDto)
    {
        var user = _dbContext.GetUserByLogin(userDto.Login);

        if (user == null || user.Password != userDto.Password)
            return BadRequest();

        var token = _authService.GenerateToken(user);

        return Ok(token);
    }

    [HttpPost]
    public IActionResult GetUsersTasks()
    {
        var tasks = _dbContext.GetAllTasks();
        return Ok(tasks);
    }

    [HttpGet, Authorize(Roles = "Admin")]
    public IActionResult GetMe()
    {
        return Ok(_userService.GetMyName());
    }
}
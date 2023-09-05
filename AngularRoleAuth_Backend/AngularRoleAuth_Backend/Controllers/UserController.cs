using AngularRoleAuth_Backend.Entities;
using AngularRoleAuth_Backend.Service.DataBase;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AngularRoleAuth_Backend.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class UserController : ControllerBase
{
    private readonly IDataBaseService _dbContext;

    public UserController(IDataBaseService dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpPost]
    [AllowAnonymous]
    public List<User> GetAllUsers()
        => _dbContext.GetAllUsers();

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public List<UserTask> GetAllTasks()
        => _dbContext.GetAllTasks();
}
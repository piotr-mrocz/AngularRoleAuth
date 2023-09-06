using AngularRoleAuth_Backend.Consts;
using AngularRoleAuth_Backend.Entities;

namespace AngularRoleAuth_Backend.Service.DataBase;

public sealed class DataBaseService : IDataBaseService
{
    public List<Entities.User> GetAllUsers()
        => DataBaseConsts.Users;

    public Entities.User? GetUserByLogin(string login)
        => DataBaseConsts.Users.FirstOrDefault(x => x.Login.ToLower() == login.ToLower());

    public List<UserTask> GetAllTasks()
        => DataBaseConsts.Tasks;
}

using AngularRoleAuth_Backend.Entities;

namespace AngularRoleAuth_Backend.Service.DataBase;

public interface IDataBaseService
{
    List<UserTask> GetAllTasks();
    List<User> GetAllUsers();
    User? GetUserByLogin(string login);
}
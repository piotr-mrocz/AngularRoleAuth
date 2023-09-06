using AngularRoleAuth_Backend.Entities;

namespace AngularRoleAuth_Backend.Service.DataBase;

public interface IDataBaseService
{
    List<UserTask> GetAllTasks();
    List<Entities.User> GetAllUsers();
    Entities.User? GetUserByLogin(string login);
}
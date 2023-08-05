using AngularRoleAuth_Backend.Entities;
using AngularRoleAuth_Backend.Enums;

namespace AngularRoleAuth_Backend;

// I don't want to play with the database like MS SQL Server, because I do it every single day
// and this is not what I want to learn
// so I create simple imitation of a database
public static class DataBaseConsts
{
    public static readonly List<User> Users = new()
    {
        new(Id: 1, Name: "Anna Karenina", Role: RoleEnum.Admin, Login: "ania", Password: "123"),
        new(Id: 2, Name: "Barbara Niechcic", Role: RoleEnum.User, Login: "basia", Password: "123")
    };

    public static readonly List<UserTask> Tasks = new()
    {
        new(Id: 1, User: Users.First(), Description: "Admin task"),
        new(Id: 2, User: Users.Last(), Description: "User task"),
    };
}

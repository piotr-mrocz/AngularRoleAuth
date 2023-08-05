using AngularRoleAuth_Backend.Enums;

namespace AngularRoleAuth_Backend.Entities;

public record User(int Id, string Name, RoleEnum Role, string Login, string Password);
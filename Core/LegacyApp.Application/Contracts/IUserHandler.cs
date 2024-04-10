using LegacyApp.Application.Reponse;
using LegacyApp.Application.Request;
using LegacyApp.Domain.Entities;

namespace LegacyApp.Application.Contracts;

public interface IUserHandler
{
    UserResponse AddUser(UserRequest  userRequest);
}



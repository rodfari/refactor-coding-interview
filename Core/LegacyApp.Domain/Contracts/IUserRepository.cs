using LegacyApp.Domain.Entities;

namespace LegacyApp.Domain.Contracts;

public interface IUserRepository
{
    void AddUser(User user);
}
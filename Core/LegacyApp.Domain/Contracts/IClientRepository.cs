using LegacyApp.Domain.Entities;

namespace LegacyApp.Domain.Contracts;

public interface IClientRepository
{
    Client GetById(int id);
}
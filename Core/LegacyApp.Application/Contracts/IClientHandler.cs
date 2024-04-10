using LegacyApp.Application.Reponse;

namespace LegacyApp.Application.Contracts;

public interface IClientHandler
{
    ClientResponse GetById(int clientId);
}

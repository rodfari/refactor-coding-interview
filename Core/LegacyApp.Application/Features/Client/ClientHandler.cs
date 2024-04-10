using LegacyApp.Application.Contracts;
using LegacyApp.Application.Reponse;
using LegacyApp.Domain.Contracts;

namespace LegacyApp.Application.Features;

public class ClientHandler : IClientHandler
{
    private readonly IClientRepository clientRepository;
    public ClientHandler(IClientRepository clientRepository)
    {
        this.clientRepository = clientRepository;

    }

    public ClientResponse GetById(int clientId)
    {
        try
        {
            var client = clientRepository.GetById(clientId);
            return new ClientResponse
            {
                ClientDto = new DTO.ClientDto
                {
                    Name = client.Name,
                    Id = client.Id,
                    ClientStatus = (int)client.ClientStatus,
                }
            };
        }
        catch (System.Exception ex)
        {
            return new ClientResponse{
                Success = false,
                Message = ex.Message
            };
        }
    }
}
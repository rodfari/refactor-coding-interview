using LegacyApp.Application.DTO;

namespace LegacyApp.Application.Reponse;

public class ClientResponse: ResponseBase
{
    public ClientDto ClientDto { get; set; }
}
using LegacyApp.Application.DTO;

namespace LegacyApp.Application.Reponse;

public class UserResponse: ResponseBase
{
    public UserDto UserDto { get; set; }
}
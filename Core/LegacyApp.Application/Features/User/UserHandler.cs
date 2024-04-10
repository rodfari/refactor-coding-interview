using LegacyApp.Application.Contracts;
using LegacyApp.Application.Reponse;
using LegacyApp.Application.Request;
using LegacyApp.Domain.Contracts;
using LegacyApp.Domain.Entities;
using LegacyApp.Domain.Enums;
using LegacyApp.Domain.Exceptions;

namespace LegacyApp.Application.Features;

public class UserHandler : IUserHandler
{
        private readonly IUserRepository userRepository;

    public UserHandler(IUserRepository userRepository)
    {
            this.userRepository = userRepository;
    }
    

    public UserResponse AddUser(UserRequest userRequest){
        try
        {
            var userDto = userRequest.UserDto;
            User user =  new(){
                 Client = new Client(){
                     Name = userDto.ClientDto.Name,
                     ClientStatus = (ClientStatus)userDto.ClientDto.ClientStatus
                 }
            };
    
            this.userRepository.AddUser(user);
            return new UserResponse {
                Success = true
            };
        }
        catch (NameMustNotBeEmptyException ex){
            return new UserResponse {
                Success = false,
                Message = ex.Message
            };
        }
        catch(EmailNotValidException ex){
            return new UserResponse{
                Success = false,
                Message = ex.Message
            };
        }
        catch(UserDateOfBirthException ex){
            return new UserResponse{
                Success = false,
                Message = ex.Message
            };
        }
        catch (System.Exception)
        {
            
            throw;
        }
    }
}
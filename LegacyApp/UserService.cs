using System;
using LegacyApp.Application.Contracts;
using LegacyApp.Application.DTO;
using LegacyApp.Application.Features;
using LegacyApp.Application.Reponse;
using LegacyApp.Application.Request;

namespace LegacyApp
{
    public class UserService
    {
        public bool AddUser(string firname, string surname, string email, DateTime dateOfBirth, int clientId)
        {
            
            ClientHandler clientHandler = new ClientHandler(new DatabaseContext.ClientRepository());
            ClientResponse response = clientHandler.GetById(clientId);
            var userDto = new UserDto
            {
                ClientDto = response.ClientDto,
                DateOfBirth = dateOfBirth,
                EmailAddress = email,
                Firstname = firname,
                Surname = surname
            };

            if (response.ClientDto.Name == "VeryImportantClient")
            {
                // Skip credit check
                userDto.HasCreditLimit = false;
            }
            else if (response.ClientDto.Name == "ImportantClient")
            {
                // Do credit check and double credit limit
                userDto.HasCreditLimit = true;
                using (var userCreditService = new UserCreditServiceClient())
                {
                    var creditLimit = userCreditService.GetCreditLimit(userDto.Firstname, userDto.Surname, userDto.DateOfBirth);
                    creditLimit = creditLimit * 2;
                    userDto.CreditLimit = creditLimit;
                }
            }
            else
            {
                // Do credit check
                userDto.HasCreditLimit = true;
                using (var userCreditService = new UserCreditServiceClient())
                {
                    var creditLimit = userCreditService.GetCreditLimit(userDto.Firstname, userDto.Surname, userDto.DateOfBirth);
                    userDto.CreditLimit = creditLimit;
                }
            }

            if (userDto.HasCreditLimit && userDto.CreditLimit < 500)
            {
                return false;
            }

            IUserHandler userHandler = new UserHandler(new DatabaseContext.UserRepository());
            UserRequest userRequest = new()
            {
                UserDto = new()
                {
                    Id = userDto.Id,
                    CreditLimit = userDto.CreditLimit,
                    DateOfBirth = userDto.DateOfBirth,
                    EmailAddress = userDto.EmailAddress,
                    Firstname = userDto.Firstname,
                    Surname = userDto.Surname,
                    HasCreditLimit = userDto.HasCreditLimit,
                    ClientDto = new()
                    {
                        ClientStatus = userDto.ClientDto.ClientStatus
                    }
                }
            };
            userHandler.AddUser(userRequest);
            return true;
        }
    }
}

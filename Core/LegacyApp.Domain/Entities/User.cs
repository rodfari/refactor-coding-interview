using System;
using LegacyApp.Domain.Exceptions;

namespace LegacyApp.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string Firstname { get; set; }

        public string Surname { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string EmailAddress { get; set; }

        public bool HasCreditLimit { get; set; }

        public int CreditLimit { get; set; }

        public Client Client { get; set; }


        public void Validate(){

            if (string.IsNullOrEmpty(Firstname) || string.IsNullOrEmpty(Surname))
            {
                throw new NameMustNotBeEmptyException("Name and surname must not be empty");
            }

            if (!EmailAddress.Contains("@") && !EmailAddress.Contains("."))
            {
               throw new EmailNotValidException("The email is not valid");
            }

            var now = DateTime.Now;
            int age = now.Year - DateOfBirth.Year;
            if (now.Month < DateOfBirth.Month || (now.Month == DateOfBirth.Month && now.Day < DateOfBirth.Day)) age--;

            if (age < 21)
            {
                throw new UserDateOfBirthException();
            }
        }
    }
}

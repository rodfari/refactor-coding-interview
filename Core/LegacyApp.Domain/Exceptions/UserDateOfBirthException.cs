namespace LegacyApp.Domain.Exceptions;

public class UserDateOfBirthException: Exception
{
    public UserDateOfBirthException()
    {
        
    }
    public UserDateOfBirthException(string message) : base(message) { }
}
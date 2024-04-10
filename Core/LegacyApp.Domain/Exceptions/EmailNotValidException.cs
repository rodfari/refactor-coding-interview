
namespace LegacyApp.Domain.Exceptions;

public class EmailNotValidException: Exception
{
    public EmailNotValidException()
    {
        
    }
    public EmailNotValidException(string message): base(message) 
    {
        
    }
}
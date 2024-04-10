namespace LegacyApp.Domain.Exceptions;

public class NameMustNotBeEmptyException: Exception
{
    public NameMustNotBeEmptyException()
    {
        
    }
    public NameMustNotBeEmptyException(string message): base(message) 
    {
        
    }
}
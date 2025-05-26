namespace Common.Domain.Exceptions;

public class InvalidResourceException : BaseDomainException
{
    public InvalidResourceException()
    {
    }
    
    public InvalidResourceException(string messageError) => base.Error = messageError;
}
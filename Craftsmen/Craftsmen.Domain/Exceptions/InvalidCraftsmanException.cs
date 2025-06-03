namespace Craftsmen.Domain.Exceptions;

using Common.Domain;

internal class InvalidCraftsmanException : BaseDomainException
{
    public InvalidCraftsmanException()
    {
    }

    public InvalidCraftsmanException(string messageError) => base.Error = messageError;
}

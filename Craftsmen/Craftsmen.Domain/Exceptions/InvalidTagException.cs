using Common.Domain;

namespace Craftsmen.Domain.Exceptions;

internal class InvalidTagException : BaseDomainException
{
    public InvalidTagException()
    {
    }

    public InvalidTagException(string messageError) => base.Error = messageError;
}
using Common.Domain;

namespace Craftsmen.Domain.Exceptions;

internal class InvalidProjectException : BaseDomainException
{
    public InvalidProjectException()
    {
    }

    public InvalidProjectException(string messageError) => base.Error = messageError;
}

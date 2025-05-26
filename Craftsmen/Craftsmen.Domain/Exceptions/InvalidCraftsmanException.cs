using Common.Domain;

namespace Craftsmen.Domain.Exceptions;

internal class InvalidCraftsmanException : BaseDomainException
{
    public InvalidCraftsmanException()
    {
    }

    public InvalidCraftsmanException(string messageError) => base.Error = messageError;
}
}

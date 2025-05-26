using Common.Domain;

namespace Craftsmen.Domain.Exceptions;

internal class InvalidCategoryException : BaseDomainException
{
    public InvalidCategoryException()
    {
    }

    public InvalidCategoryException(string messageError) => base.Error = messageError;
}

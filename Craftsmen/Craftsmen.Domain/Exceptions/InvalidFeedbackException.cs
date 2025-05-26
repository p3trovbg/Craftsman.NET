using Common.Domain;

namespace Craftsmen.Domain.Exceptions;

internal class InvalidFeedbackException : BaseDomainException
{
    public InvalidFeedbackException()
    {
    }

    public InvalidFeedbackException(string messageError) => base.Error = messageError
}

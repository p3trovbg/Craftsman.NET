namespace Craftsmen.Domain.Exceptions;

using Common.Domain;

internal class InvalidFeedbackException : BaseDomainException
{
    public InvalidFeedbackException()
    {
    }

    public InvalidFeedbackException(string messageError) => base.Error = messageError;
}

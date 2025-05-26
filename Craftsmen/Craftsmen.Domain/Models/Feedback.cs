namespace Craftsmen.Domain.Models;

using Common.Domain;
using Common.Domain.Models;
using Exceptions;

public class Feedback : Entity<int>
{
    internal Feedback(string content, int rating, string writerId)
    {
        this.Validate(content, rating, writerId);

        this.Content = content;
        this.Rating = rating;
        this.WriterId = writerId;
    }

    public string Content { get; private set; }

    public int Rating { get; private set; }

    public string WriterId { get; private set; }

    private void Validate(string content, int rating, string writerId)
    {
        Guard.AgainstEmptyString<InvalidFeedbackException>(content, nameof(this.Content));
        Guard.AgainstOutOfRange<InvalidFeedbackException>(rating, 1, 10, nameof(this.Rating));
        Guard.AgainstEmptyString<InvalidFeedbackException>(writerId, nameof(this.WriterId));
    }
}
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

    public Feedback UpdateContent(string newContent)
    {
        this.ValidateContent(newContent);
        this.Content = newContent;

        return this;    
    }

     public Feedback UpdateRating(int newRating)
    {
        this.ValidateRating(newRating);
        this.Rating = newRating;

        return this;    
    }

    private void Validate(string content, int rating, string writerId)
    {
        this.ValidateContent(content);
        this.ValidateRating(rating);
        this.ValidateWriterId(writerId);
    }

    private void ValidateContent(string content)
        => Guard.AgainstEmptyString<InvalidFeedbackException>(content, nameof(this.Content));

    private void ValidateRating(int rating)
        => Guard.AgainstOutOfRange<InvalidFeedbackException>(rating, 1, 10, nameof(this.Rating));

    private void ValidateWriterId(string writerId)
        => Guard.AgainstEmptyString<InvalidFeedbackException>(writerId, nameof(this.WriterId));
}
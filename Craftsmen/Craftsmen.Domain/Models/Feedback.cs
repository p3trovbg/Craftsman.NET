using Common.Domain.Models;

namespace Craftsmen.Domain.Models;

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
        throw new NotImplementedException();
    }
}
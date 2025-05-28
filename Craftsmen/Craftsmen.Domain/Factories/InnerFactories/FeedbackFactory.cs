namespace Craftsmen.Domain.Factories.InnerFactories;

using Craftsmen.Domain.Models;

public class FeedbackFactory
{
    private string content = default!;
    private int rating = default!;
    private string writerId = default!;

    public FeedbackFactory WithContent(string content)
    {
        this.content = content;
        return this;
    }

    public FeedbackFactory WithRating(int rating)
    {
        this.rating = rating;
        return this;
    }

    public FeedbackFactory WithWriterId(string writerId)
    {
        this.writerId = writerId;
        return this;
    }

    internal Feedback Build() => new Feedback(this.content, this.rating, this.writerId);
    
}
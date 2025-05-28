namespace Craftsmen.Domain.Factories.InnerFactories;

using Common.Domain.Models;
using Models;

public class ProjectFactory
{
    private string name = default!;
    private string description = default!;
    private int durationInWeeks = default!;
    private readonly List<Feedback> feedbacks = new List<Feedback>();
    private readonly List<Tag> tags = new List<Tag>();
    private readonly List<Resource> resources = new List<Resource>();

    public ProjectFactory WithName(string name)
    {
        this.name = name;
        return this;
    }

    public ProjectFactory WithDescription(string description)
    {
        this.description = description;
        return this;
    }

    public ProjectFactory WithDurationInWeeks(int durationInWeeks)
    {
        this.durationInWeeks = durationInWeeks;
        return this;
    }

    public ProjectFactory WithFeedback(Action<FeedbackFactory> feedback)
    {
        var feedbackFactory = new FeedbackFactory();
        feedback(feedbackFactory);
        feedbacks.Add(feedbackFactory.Build());

        return this;
    }

    public ProjectFactory WithTag(string name)
    {
        var tag = new Tag(name);
        this.tags.Add(tag);

        return this;
    }

    // TODO: add resources

    internal Project Build()
    {
        var project = new Project(this.name, this.description, this.durationInWeeks);

        tags.ForEach(project.AddTag);
        feedbacks.ForEach(project.AddFeedback);
        resources.ForEach(project.AddResource);

        return project;
    }
}

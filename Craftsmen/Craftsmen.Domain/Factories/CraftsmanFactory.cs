namespace Craftsmen.Domain.Factories;

using Common.Domain.Models;
using Models;
using InnerFactories;

public class CraftsmanFactory : ICraftsmanFactory
{
    private string name = default!;
    private string description = default!;
    private string location = default!;
    private Category category = default!;
    private string userId = default!;
    private readonly List<Feedback> feedbacks = new List<Feedback>();
    private readonly List<Project> projects = new List<Project>();
    private readonly List<Resource> resources = new List<Resource>();

    public ICraftsmanFactory WithName(string name)
    {
        this.name = name;
        return this;
    }
    public ICraftsmanFactory WithDescription(string description)
    {
        this.description = description;
        return this;
    }

    public ICraftsmanFactory WithLocation(string location)
    {
        this.location = location;
        return this;
    }

    public ICraftsmanFactory WithCategory(Action<CategoryFactory> category)
    {
        var categoryFactory = new CategoryFactory();
        category(categoryFactory);
        this.category = categoryFactory.Build();

        return this;
    }

    public ICraftsmanFactory FromUser(string userId)
    {
        this.userId = userId;
        return this;
    }

    public ICraftsmanFactory WithFeedback(Action<FeedbackFactory> feedback)
    {
        var feedbackFactory = new FeedbackFactory();
        feedback(feedbackFactory);
        this.feedbacks.Add(feedbackFactory.Build());

        return this;
    }

    public ICraftsmanFactory WithProject(Action<ProjectFactory> project)
    {
        var projectFactory = new ProjectFactory();
        project(projectFactory);
        this.projects.Add(projectFactory.Build());

        return this;
    }

    // TODO: Add resources

    public Craftsman Build()
    {
        var craftsman = new Craftsman(name, description, userId, location, category);

        feedbacks.ForEach(craftsman.AddFeedback);
        projects.ForEach(craftsman.AddProject);
        resources.ForEach(craftsman.AddResource);

        return craftsman;
    }
}

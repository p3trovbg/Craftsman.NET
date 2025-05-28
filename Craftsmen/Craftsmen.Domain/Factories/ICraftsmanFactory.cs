namespace Craftsmen.Domain.Factories;

using Common.Domain.Contracts;
using Models;
using InnerFactories;

public interface ICraftsmanFactory : IFactory<Craftsman>
{
    ICraftsmanFactory WithName(string name);

    ICraftsmanFactory WithDescription(string description);

    ICraftsmanFactory WithLocation(string location);

    ICraftsmanFactory WithCategory(Action<CategoryFactory> category);

    ICraftsmanFactory WithFeedback(Action<FeedbackFactory> feedback);

    ICraftsmanFactory WithProject(Action<ProjectFactory> project);

    ICraftsmanFactory FromUser(string userId);
}

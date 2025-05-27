using Common.Domain.Contracts;

using Craftsmen.Domain.Models;

namespace Craftsmen.Domain.Factories;
public interface ICraftsmanFactory : IFactory<Craftsman>
{
    ICraftsmanFactory WithName(string name);

    ICraftsmanFactory WithDescription(string description);

    ICraftsmanFactory WithLocation(string location);

    ICraftsmanFactory WithCategory(Category category);

    ICraftsmanFactory WithFeedback(Action<FeedbackFactory> feedback);

    ICraftsmanFactory FromUser(string userId);
}

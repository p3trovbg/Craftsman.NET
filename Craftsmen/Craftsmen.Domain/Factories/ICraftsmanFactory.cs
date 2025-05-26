using Common.Domain.Contracts;

using Craftsmen.Domain.Models;

namespace Craftsmen.Domain.Factories;
public interface ICraftsmanFactory : IFactory<Craftsman>
{
    ICraftsmanFactory WithName(string name);

    ICraftsmanFactory WithDescription(string description);

    ICraftsmanFactory WithLocation(string location);

    ICraftsmanFactory WithCategory(Category category);

    ICraftsmanFactory FromUser(string userId);
}

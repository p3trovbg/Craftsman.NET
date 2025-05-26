namespace Craftsmen.Domain.Factories;

using Models;

public class CraftsmanFactory : ICraftsmanFactory
{
    private string name = default!;
    private string description = default!;
    private string location = default!;
    private Category category = default!;
    private string userId = default!;

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

    public ICraftsmanFactory WithCategory(Category category)
    {
        this.category = category;
        return this;
    }

    public ICraftsmanFactory FromUser(string userId)
    {
        this.userId = userId;
        return this;
    }

    public Craftsman Build() => new Craftsman(name, description, userId, location, category);
}

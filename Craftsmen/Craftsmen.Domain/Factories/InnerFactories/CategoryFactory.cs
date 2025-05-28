namespace Craftsmen.Domain.Factories.InnerFactories;

using Models;

public class CategoryFactory
{
    private string name = default!;
    private string? description = default!;

    public CategoryFactory WithName(string name)
    {
        this.name = name;
        return this;
    }

    public CategoryFactory WithDescription(string description)
    {
        this.description = description;
        return this;
    }

    internal Category Build() => new Category(name, description);
}

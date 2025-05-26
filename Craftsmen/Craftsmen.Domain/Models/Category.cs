using Common.Domain;
using Common.Domain.Models;

namespace Craftsmen.Domain.Models;

public class Category : Entity<int>
{
    internal Category(string name, string description)
    {
        this.Validate(name, description);

        this.Name = name;
        this.Description = description;
    }

    public string Name { get; private set; }

    public string Description { get; private set; }

    private void Validate(string name, string description)
    {
        Guard.ForStringLength<>
    }
}
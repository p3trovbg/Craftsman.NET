namespace Craftsmen.Domain.Models;

using Common.Domain;
using Common.Domain.Models;
using Exceptions;

public class Category : Entity<int>
{
    internal Category(string name, string? description)
    {
        this.Validate(name, description);

        this.Name = name;
        this.Description = description;
    }

    public string Name { get; private set; }

    public string? Description { get; private set; }

    private void Validate(string name, string? description)
    {
        Guard.ForStringLength<InvalidCategoryException>(name, 3, 40, nameof(this.Name));

        if (!string.IsNullOrWhiteSpace(description))
        {
            Guard.ForStringLength<InvalidCategoryException>(description, 5, 200, nameof(this.Description));
        }
    }
}
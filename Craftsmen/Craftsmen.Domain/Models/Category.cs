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

    public Category UpdateName(string newName)
    {
        this.ValidateName(newName);
        this.Name = newName;

        return this;
    }

    public Category UpdateDescription(string description)
    {
        this.ValidateDescription(description);
        this.Description = description;

        return this;
    }

    private void Validate(string name, string? description)
    {
        this.ValidateName(name);
        this.ValidateDescription(description);
    }

    private void ValidateName(string name) 
        => Guard.ForStringLength<InvalidCategoryException>(name, 3, 40, nameof(this.Name));

    private void ValidateDescription(string? description)
    {
        if (!string.IsNullOrWhiteSpace(description))
        {
            Guard.ForStringLength<InvalidCategoryException>(description, 5, 200, nameof(this.Description));
        }
    }
}
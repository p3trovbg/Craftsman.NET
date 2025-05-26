using Common.Domain.Models;

namespace Craftsmen.Domain.Models;

// NOTE: Tag could be used by projects, workshops and forum. Therefore we could move in Common.Domain models.
public class Tag : Entity<int>
{
    internal Tag(string name)
    {
        this.Validate(name);

        this.Name = name;
    }

    public string Name { get; private set; }

    private void Validate(string name)
    {
        throw new NotImplementedException();
    }
}
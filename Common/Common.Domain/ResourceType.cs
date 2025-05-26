using Common.Domain.Models;

namespace Common.Domain;

public class ResourceType : Enumeration
{
    public static readonly ResourceType Image = new(0, nameof(Image));
    public static readonly ResourceType Video = new(1, nameof(Video));
    public static readonly ResourceType Document = new(2, nameof(Document));

    private ResourceType(int value) : this(value, FromValue<ResourceType>(value).Name)
    {
    }

    private ResourceType(int value, string name) : base(value, name)
    {
    }
}
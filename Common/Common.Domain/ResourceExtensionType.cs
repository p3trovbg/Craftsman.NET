using Common.Domain.Models;

namespace Common.Domain;

public class ResourceExtensionType : Enumeration
{
    public static readonly ResourceExtensionType Jpg = new(0, nameof(Jpg));
    public static readonly ResourceExtensionType Png = new(1, nameof(Png));
    public static readonly ResourceExtensionType Webp = new(2, nameof(Webp));
    public static readonly ResourceExtensionType Mp4 = new(3, nameof(Mp4));
    public static readonly ResourceExtensionType Docs = new(4, nameof(Docs));
    public static readonly ResourceExtensionType Pdf = new(5, nameof(Pdf));

    private ResourceExtensionType(int value) : this(value, FromValue<ResourceExtensionType>(value).Name)
    {
    }

    private ResourceExtensionType(int value, string name) : base(value, name)
    {
    }
}
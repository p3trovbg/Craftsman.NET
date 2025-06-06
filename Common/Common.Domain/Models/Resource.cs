﻿using Common.Domain.Exceptions;

using static Common.Domain.Constants.Resources;

namespace Common.Domain.Models;

public class Resource : Entity<Guid>
{
    internal Resource(
        string name,
        int? sizeInKilobytes,
        string? description,
        string? path,
        byte[]? content,
        ResourceType type,
        ResourceExtensionType extensionType)
    {
        this.Validate(name, description, path, content, type, extensionType);
        this.Name = name;
        this.SizeInKilobytes = sizeInKilobytes ?? content?.Length ?? default;
        this.Description = description;
        this.Path = path;
        this.Content = content;
        this.Type = type;
        this.ExtensionType = extensionType;
    }

    public string Name { get; private set; }

    public string? Description { get; private set; }

    public int? SizeInKilobytes { get; private set; }

    public string? Path { get; private set; }

    public byte[]? Content { get; private set; }

    public ResourceType Type { get; private set; }

    public ResourceExtensionType ExtensionType { get; private set; }

    private void Validate(
        string name,
        string? description,
        string? path,
        byte[]? content,
        ResourceType type,
        ResourceExtensionType extensionType)
    {
        if ((content == null || content.Length == 0) && string.IsNullOrWhiteSpace(path))
        {
            throw new InvalidResourceException(ErrorContentOrPathRequired);
        }

        if (content is { Length: > 0 } && !string.IsNullOrWhiteSpace(path))
        {
            throw new InvalidResourceException(ErrorBothContentAndPath);
        }

        Guard.ForStringLength<InvalidResourceException>(name, MinNameLength, MaxNameLength, nameof(this.Name));

        if (!string.IsNullOrWhiteSpace(description))
        {
            Guard.ForStringLength<InvalidResourceException>(description, MinDescriptionLength, MaxDescriptionLength, nameof(this.Description));
        }

        if (content != null)
        {
            Guard.ForStringLength<InvalidResourceException>(path!, MinSizeInBytes, MaxSizeInBytes, nameof(this.Path));
        }

        if (content == null && !string.IsNullOrWhiteSpace(path))
        {
            if (path.Contains("..") || path.StartsWith("/") || path.Contains("//"))
            {
                throw new InvalidResourceException(ErrorInvalidPathCharacters);
            }

            if (!Uri.IsWellFormedUriString(path, UriKind.RelativeOrAbsolute))
            {
                throw new InvalidResourceException(ErrorInvalidPathUri);
            }
        }

        if (type.Equals(ResourceType.Image))
        {
            bool isValidFormat = extensionType.Equals(ResourceExtensionType.Png) ||
                                 extensionType.Equals(ResourceExtensionType.Jpg) ||
                                 extensionType.Equals(ResourceExtensionType.Webp);

            if (!isValidFormat)
            {
                throw new InvalidResourceException(string.Format(ErrorUnsupportedExtension, type, extensionType));
            }
        }
        else if (type.Equals(ResourceType.Video))
        {
            bool isValidFormat = extensionType.Equals(ResourceExtensionType.Mp4);

            if (!isValidFormat)
            {
                throw new InvalidResourceException(string.Format(ErrorUnsupportedExtension, type, extensionType));
            }
        }
        else if (type.Equals(ResourceType.Document))
        {
            bool isValidFormat = extensionType.Equals(ResourceExtensionType.Pdf) ||
                                 extensionType.Equals(ResourceExtensionType.Docs);

            if (!isValidFormat)
            {
                throw new InvalidResourceException(string.Format(ErrorUnsupportedExtension, type, extensionType));
            }
        }
    }
}
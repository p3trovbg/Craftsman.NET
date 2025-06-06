﻿namespace Craftsmen.Domain.Models;

using Common.Domain;
using Common.Domain.Models;
using Exceptions;

using static Common.Domain.Constants.Tag;

// NOTE: Tag could be used by projects, workshops and forum. Therefore we could move in Common.Domain models.
public class Tag : Entity<int>
{
    internal Tag(string name)
    {
        this.Validate(name);

        this.Name = name;
    }

    public string Name { get; private set; }

    public Tag UpdateName(string name)
    {
        this.Validate(name);
        this.Name = name;

        return this;
    }

    private void Validate(string name)
    {
        Guard.ForStringLength<InvalidTagException>(name, NameMinLength, NameMaxLength, nameof(this.Name));
    }
}
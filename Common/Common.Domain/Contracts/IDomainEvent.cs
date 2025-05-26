namespace Common.Domain;

public interface IDomainEvent
{
    Action Handle { get; }
}
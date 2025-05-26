namespace Common.Domain.Models;

public class AuditInfo : ValueObject
{
    internal AuditInfo(string? createdBy = default)
    {
        this.CreatedOn = DateTime.UtcNow;
        this.CreatedBy = createdBy;
    }

    public DateTime CreatedOn { get; }

    public string? CreatedBy { get; }

    public DateTime? ModifiedOn { get; private set; }

    public string? ModifiedBy { get; private set; }

    internal void MarkAsModified(string modifiedBy)
    {
        ModifiedOn = DateTime.UtcNow;
        this.ModifiedBy = modifiedBy;
    }
}

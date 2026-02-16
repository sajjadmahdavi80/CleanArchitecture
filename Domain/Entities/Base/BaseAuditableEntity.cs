namespace Domain.Entities.Base;

public abstract class BaseAuditableEntity : BaseEntity
{
    public DateTime Created { get; set; }

    public DateTime? LaseModified { get; set; } = DateTime.Now;
}

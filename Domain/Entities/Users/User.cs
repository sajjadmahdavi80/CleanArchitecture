using Domain.Entities.Base;
using Domain.Enums;

namespace Domain.Entities.Users;

/// <summary>
/// 
/// </summary>
public sealed class User : BaseAuditableEntity
{
    public string FullName { get; set; }

    public Status Status { get; set; }
}

using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities.Base;

namespace Domain.Entities.Users;

public sealed class UserRoles : BaseAuditableEntity
{
    public int RoleId { get; set; }
    public Role Role { get; set; }

    public int UserId { get; set; }
    public User User { get; set; }
}

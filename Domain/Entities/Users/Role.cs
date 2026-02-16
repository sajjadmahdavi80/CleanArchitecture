using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities.Base;
using Domain.Enums;

namespace Domain.Entities.Users;

public sealed class Role : BaseAuditableEntity
{
    public string RoleTitle { get; set; }

    public Status Status { get; set; }

}

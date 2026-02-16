using System;
using System.Collections.Generic;
using System.Text;
using Domain.Enums;

namespace Application.Users.DTOs;

public record class BasicUserInformationDTO
{
    public string FullName { get; set; }

    public Status Status { get; set; }
}

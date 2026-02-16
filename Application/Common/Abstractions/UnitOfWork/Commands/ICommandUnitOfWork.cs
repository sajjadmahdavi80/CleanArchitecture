using System;
using System.Collections.Generic;
using System.Text;
using Application.Users.Repositories.Commands;
using Domain.Entities.Users;

namespace Application.Common.Abstractions.UnitOfWork.Commands;

public interface ICommandUnitOfWork : IDisposable
{
    ICommandUserRepository User { get; }

    Task<bool> SaveChangesAsync();
}

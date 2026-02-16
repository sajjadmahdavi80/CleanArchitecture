using System;
using System.Collections.Generic;
using System.Text;
using Application.Users.Repositories.Commands;
using Application.Users.Repositories.Queries;

namespace Application.Common.Abstractions.UnitOfWork.Query;

public interface IQueryUnitOfWork : IDisposable
{
    IQueryUserRepository User { get; }
}

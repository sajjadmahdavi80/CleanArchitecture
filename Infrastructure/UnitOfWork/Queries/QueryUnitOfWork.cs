using System;
using System.Collections.Generic;
using System.Text;
using Application.Common.Abstractions.UnitOfWork.Commands;
using Application.Common.Abstractions.UnitOfWork.Query;
using Application.Users.Repositories.Commands;
using Application.Users.Repositories.Queries;
using Infrastructure.Repository.RelationalDbs.Commands;
using Infrastructure.Repository.RelationalDbs.Queries;

namespace Infrastructure.UnitOfWork.Queries;

internal class QueryUnitOfWork : IQueryUnitOfWork
{
    private readonly QueryDbContext context;


    public QueryUnitOfWork(QueryDbContext dbContext, IQueryUserRepository userRepository)
    {
        context = dbContext;
        User ??= userRepository;
    }
    private bool disposedValue;


    public IQueryUserRepository User { get; }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                context.Dispose();
            }
            disposedValue = true;
        }
    }

    void IDisposable.Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}

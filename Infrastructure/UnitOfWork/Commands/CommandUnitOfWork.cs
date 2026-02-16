using Application.Common.Abstractions.UnitOfWork.Commands;
using Application.Users.Repositories.Commands;
using Infrastructure.Repository.RelationalDbs.Commands;

namespace Infrastructure.UnitOfWork.Commands;

internal class CommandUnitOfWork : ICommandUnitOfWork
{
    private readonly CommandDbContext context;


    public CommandUnitOfWork(CommandDbContext dbContext, ICommandUserRepository userRepository)
    {
        context = dbContext;
        User ??= userRepository;
    }
    private bool disposedValue;


    public ICommandUserRepository User { get; }

    async Task<bool> ICommandUnitOfWork.SaveChangesAsync()
    {
        return await context.SaveChangesAsync() > 0;
    }
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

using System.Globalization;
using System.Linq.Expressions;
using System.Numerics;
using Application.Common.Abstractions.Contexts.Commands;
using Application.Common.Abstractions.Repository.Commands;
using Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.RelationalDbs.Commands;

internal abstract class CommandGenericRepository<T> : ICommandGenericRepository<T> where T : class
{
    protected DbSet<T> _dbSet;
    protected CommandDbContext context;
    protected CommandGenericRepository(CommandDbContext context)
    {
        this.context = context;
        _dbSet = context.Set<T>();
    }

    public async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public async Task AddAsync(IEnumerable<T> entities)
    {
        await _dbSet.AddRangeAsync(entities);
    }

    public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> conditions)
    {
        return await _dbSet.FirstOrDefaultAsync(conditions);
    }
    public async Task<T> GetById<TNumber>(TNumber id) where TNumber : INumber<TNumber>
    {
        return await _dbSet.FindAsync(id);
    }
    public async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> conditions)
    {
        return await _dbSet.Where(conditions).ToHashSetAsync();
    }
    public async Task UpdateAsync(T entity)
    {
        _dbSet.Update(entity);
    }

    public async Task<bool> RemoveAsync(T entity)
    {
        _dbSet.Remove(entity);
        return true;
    }

    public async Task<bool> RemoveAsync<TNumber>(TNumber id) where TNumber : INumber<TNumber>
    {
        T entity = await GetById(id);
        if (entity != null)
        {
            _dbSet.Remove(entity);
            return true;
        }
        return false;
    }

    //public async Task<bool> SaveChangeAsync()
    //{
    //    return await context.SaveChangesAsync() > 0;
    //}

    //public async Task<bool> SaveChangeAsync(CancellationToken cancellationToken)
    //{
    //    return await context.SaveChangesAsync(cancellationToken) > 0;
    //}
}

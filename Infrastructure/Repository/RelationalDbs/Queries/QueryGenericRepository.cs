using System.Linq.Expressions;
using Application.Common.Abstractions.Repository.Queries;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.RelationalDbs.Queries;

internal abstract class QueryGenericRepository<T> : IQueryGenericRepository<T> where T : class
{
    protected DbSet<T> _dbSet;
    protected QueryDbContext context;
    protected QueryGenericRepository(QueryDbContext context)
    {
        this.context = context;
        _dbSet = context.Set<T>();
    }
    public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> conditions)
    {
        return await _dbSet.FirstOrDefaultAsync(conditions);
    }

    public async Task<TResult> FirstOrDefaultAsync<TResult>(Expression<Func<T, bool>> conditions, Expression<Func<T, TResult>> selector) where TResult : class
    {
        return await _dbSet.Where(conditions).Select(selector).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<TResult>> GetAsync<TResult>(Expression<Func<T, bool>> conditions, Expression<Func<T, TResult>> selector)
        where TResult : class
    {
        return await _dbSet.Where(conditions).Select(selector).ToHashSetAsync();
    }

    public async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> conditions)
    {
        return await _dbSet.Where(conditions).ToHashSetAsync();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }
}

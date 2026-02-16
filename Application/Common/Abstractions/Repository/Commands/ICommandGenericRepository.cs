using System.Linq.Expressions;
using System.Numerics;
using Domain.Entities.Base;

namespace Application.Common.Abstractions.Repository.Commands;

public interface ICommandGenericRepository<T> : ICommandRepository where T : class
{
    Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> conditions);
    Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> conditions);

    Task<T> GetById<TNumber>(TNumber id) where TNumber : INumber<TNumber>;
    Task<bool> RemoveAsync<TNumber>(TNumber id) where TNumber : INumber<TNumber>;

    Task<bool> RemoveAsync(T entity);

    Task AddAsync(T entity);
    Task AddAsync(IEnumerable<T> entities);

    Task UpdateAsync(T entity);

    
}

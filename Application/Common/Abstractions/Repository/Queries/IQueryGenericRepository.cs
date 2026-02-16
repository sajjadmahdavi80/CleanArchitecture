using System.Linq.Expressions;
using Domain.Entities.Base;

namespace Application.Common.Abstractions.Repository.Queries;

public interface IQueryGenericRepository<T> : IQueryRepository where T : class
{
    Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> conditions);
    Task<T> GetByIdAsync(int id);
    Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> conditions);

    Task<TResult> FirstOrDefaultAsync<TResult>(Expression<Func<T, bool>> conditions, Expression<Func<T, TResult>> selector)
      where TResult : class;
    Task<IEnumerable<TResult>> GetAsync<TResult>(Expression<Func<T, bool>> conditions, Expression<Func<T, TResult>> selector)
      where TResult : class;
}

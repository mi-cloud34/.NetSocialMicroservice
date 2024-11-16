using System.Linq.Expressions;
using System.Threading;
using Microsoft.EntityFrameworkCore.Query;

namespace Core.Persistance.Repositories;

public interface IAsyncRepository<T> : IQuery<T> where T : Entity
{

    Task<T?> GetAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>,
                      IIncludableQueryable<T, object>>? include = null, bool enableTracking = true,
                      CancellationToken cancellationToken = default);

    Task<IQueryable<T>> GetAllAsync(
       Expression<Func<T, bool>>? predicate = null,
       Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
       Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
       bool enableTracking = true,
       CancellationToken cancellationToken = default
    );
    /// Task<IQueryable<T?>> GetAllAsync(Expression<Func<T, bool>>? filter=null,Boolean tracking=true, CancellationToken cancellationToken = default);
    Task<T> AddAsync(T entity);
    Task<T> FollowAsync(T entity);
    Task<T> AddConservationAsync(T entity);
    Task<T> UnfollowAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task<T> DeleteAsync(T entity);
    Task<IList<T>> AddRangeAsync(List<T> entity);
}
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Core.Persistance.Repositories;

public class EfRepositoryBase<TEntity, TContext> : IAsyncRepository<TEntity>, IRepository<TEntity>
    where TEntity : Entity
    where TContext : DbContext
{
    protected TContext _context { get; }

    public EfRepositoryBase(TContext context)
    {
        _context = context;
    }
    public DbSet<TEntity> Table => _context.Set<TEntity>();
    public TEntity Get(Expression<Func<TEntity, bool>> filter)
    {

        return _context.Set<TEntity>().SingleOrDefault(filter);

    }

    public List<TEntity> GetAll(Expression<Func<TEntity, bool>>? filter)
    {

        return filter is null ?
            _context.Set<TEntity>().ToList() :
            _context.Set<TEntity>().Where(filter).ToList();
    }

    public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>,
                                        IIncludableQueryable<TEntity, object>>? include = null, bool enableTracking = true,
                                        CancellationToken cancellationToken = default)
    {
        IQueryable<TEntity> queryable = Query().AsQueryable();
        if (!enableTracking) queryable = queryable.AsNoTracking();
        if (include != null) queryable = include(queryable);
        return await queryable.FirstOrDefaultAsync(predicate, cancellationToken);
    }

    public async Task<IQueryable<TEntity?>> GetAllAsync(Expression<Func<TEntity, bool>>? predicate = null,
       Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
       Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
       bool enableTracking = true,
       CancellationToken cancellationToken = default)
    {
        IQueryable<Entity?> query = Table.Where(predicate);
        return (IQueryable<TEntity?>)await Task.FromResult(enableTracking ? query : query.AsNoTracking());
        //return filter is null ?
        //         _context.Set<TEntity>().ToList() :
        //         _context.Set<TEntity>().Where(filter).ToList();
    }
    public IQueryable<TEntity> Query()
    {
        return _context.Set<TEntity>();
    }

    public async Task<TEntity> AddAsync(TEntity entity)
    {
        _context.Entry(entity).State = EntityState.Added;
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<TEntity> DeleteAsync(TEntity entity)
    {
        _context.Entry(entity).State = EntityState.Deleted;
        await _context.SaveChangesAsync();
        return entity;
    }




    public TEntity Add(TEntity entity)
    {
        _context.Entry(entity).State = EntityState.Added;
        _context.SaveChanges();
        return entity;
    }

    public TEntity Update(TEntity entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        _context.SaveChanges();
        return entity;
    }

    public TEntity Delete(TEntity entity)
    {
        _context.Entry(entity).State = EntityState.Deleted;
        _context.SaveChanges();
        return entity;
    }

    public Task<IList<TEntity>> AddRangeAsync(List<TEntity> entity)
    {
        _context.Entry(entity).State = EntityState.Added;
        _context.SaveChanges();
        return default!;
    }


    public async Task<TEntity> FollowAsync(TEntity entity)
    {
        _context.Entry(entity).State = EntityState.Added;
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<TEntity> UnfollowAsync(TEntity entity)
    {
        _context.Entry(entity).State = EntityState.Deleted;
        _context.SaveChanges();
        return entity;
    }
    public async Task<TEntity> AddConservationAsync(TEntity entity)
    {
        _context.Entry(entity).State = EntityState.Added;
        await _context.SaveChangesAsync();
        return entity;
    }


    public TEntity Follow(TEntity entity)
    {
        _context.Entry(entity).State = EntityState.Added;
        _context.SaveChanges();
        return entity;
    }

    public TEntity Unfollow(TEntity entity)
    {
        _context.Entry(entity).State = EntityState.Deleted;
        _context.SaveChanges();
        return entity;
    }


}















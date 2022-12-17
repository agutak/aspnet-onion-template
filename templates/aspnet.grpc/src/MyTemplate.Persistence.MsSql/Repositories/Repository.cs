using MyTemplate.Domain.Common;

namespace MyTemplate.Persistence.MsSql.Repositories;

internal abstract class Repository<T, TId> : IRepository<T, TId> 
    where T : class, IEntity<TId>
    where TId : struct, IEquatable<TId>, IComparable<TId>
{
    protected readonly MyTemplateContext _dbContext;
    protected readonly DbSet<T> _set;
    protected readonly IQueryable<T> _readOnlySet;

    public Repository(MyTemplateContext dbContext)
    {
        _dbContext = dbContext;
        _set = dbContext.Set<T>();
        _readOnlySet = dbContext.Set<T>().AsNoTracking();
    }

    public virtual Task AddAsync(T entity, CancellationToken cancellation = default)
    {
        _set.Add(entity);
        return Task.CompletedTask;
    }

    public virtual async Task<List<T>> GetAllAsync(CancellationToken cancellation)
    {
        return await _set
            .ToListAsync(cancellation);
    }

    public virtual async Task<T?> GetAsync(TId id, CancellationToken cancellation)
    {
        return await _set
            .FirstOrDefaultAsync(x => x.EntityId.Equals(id), cancellation);
    }

    public virtual Task UpdateAsync(T entity, CancellationToken cancellation = default)
    {
        _set.Update(entity);
        return Task.CompletedTask;
    }
}

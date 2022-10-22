using MyTemplate.Domain.Common;

namespace MyTemplate.Application.Repositories;

public interface IRepository<T, TId>
    where T : class, IEntity<TId>
    where TId : struct, IEquatable<TId>, IComparable<TId>
{
    Task AddAsync(T entity, CancellationToken cancellation = default);
    Task<List<T>> GetAllAsync(CancellationToken cancellation);
    Task<T?> GetAsync(TId id, CancellationToken cancellation);
    Task UpdateAsync(T entity, CancellationToken cancellation = default);
}

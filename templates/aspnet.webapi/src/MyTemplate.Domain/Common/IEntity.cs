namespace MyTemplate.Domain.Common;

public interface IEntity<TId> where TId : struct, IEquatable<TId>, IComparable<TId>
{
    TId EntityId { get; }
}

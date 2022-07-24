namespace MyTemplate.Persistence.MongoDb.Repositories;

internal abstract class Repository<T, TId> : IRepository<T, TId>
    where T : class, IEntity<TId>
    where TId : struct, IEquatable<TId>, IComparable<TId>
{
    protected readonly IMongoDbContext _dbContext;
    protected readonly IMongoCollection<T> _collection;

    public Repository(IMongoDbContext dbContext, string collectionName)
    {
        _dbContext = dbContext;
        _collection = _dbContext.GetCollection<T>(collectionName);
    }

    public virtual async Task AddAsync(T entity, CancellationToken cancellation)
    {
        var session = await _dbContext.GetSessionAsync(cancellation);
        
        await _collection.InsertOneAsync(
            session,
            entity,
            cancellationToken: cancellation);
    }

    public virtual async Task<List<T>> GetAllAsync(CancellationToken cancellation)
    {
        return await _collection
            .AsQueryable()
            .ToListAsync(cancellation);
    }

    public virtual async Task<T?> GetAsync(TId id, CancellationToken cancellation)
    {
        var filter = Builders<T>.Filter.Where(x => x.EntityId.Equals(id));

        return await _collection
            .Find(filter)
            .FirstOrDefaultAsync(cancellation);
    }

    public virtual async Task UpdateAsync(T entity, CancellationToken cancellation)
    {
        var session = await _dbContext.GetSessionAsync(cancellation);

        var filter = Builders<T>.Filter.Where(x => x.EntityId.Equals(entity.EntityId));

        _ = await _collection
            .FindOneAndReplaceAsync(
                session,
                filter,
                entity,
                cancellationToken: cancellation);
    }
}

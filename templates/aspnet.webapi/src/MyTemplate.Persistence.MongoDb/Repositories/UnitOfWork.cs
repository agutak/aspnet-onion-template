namespace MyTemplate.Persistence.MongoDb.Repositories;

internal sealed class UnitOfWork : IUnitOfWork
{
    private readonly IMongoDbContext _dbContext;

    public UnitOfWork(IMongoDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task CompleteAsync(CancellationToken cancellation)
    {
        var session = await _dbContext.GetSessionAsync(cancellation);
        
        // For Clusters only
        //await session.CommitTransactionAsync(cancellation);
    }
}

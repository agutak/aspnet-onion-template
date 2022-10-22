namespace MyTemplate.Persistence.MongoDb.Context;

internal interface IMongoDbContext
{
    IMongoCollection<T> GetCollection<T>(string collectionName);
    ValueTask<IClientSessionHandle> GetSessionAsync(CancellationToken cancellation);
}

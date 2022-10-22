namespace MyTemplate.Persistence.MongoDb.Context;

internal class MongoDbContext : IMongoDbContext, IDisposable
{
    private readonly MongoClient _client;
    private readonly IMongoDatabase _database;
    private IClientSessionHandle? _sessionHandle;

    public MongoDbContext(MongoClient mongoClient, IMongoDatabase mongoDatabase)
    {
        _client = mongoClient;
        _database = mongoDatabase;
    }

    public IMongoCollection<T> GetCollection<T>(string collectionName)
    {
        return _database.GetCollection<T>(collectionName);
    }

    public async ValueTask<IClientSessionHandle> GetSessionAsync(CancellationToken cancellation)
    {
        if (_sessionHandle is null)
        {
            _sessionHandle = await _client.StartSessionAsync(cancellationToken: cancellation);

            // For Clusters only
            //_sessionHandle.StartTransaction();
        }

        return _sessionHandle;
    }

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            _sessionHandle?.Dispose();
            _sessionHandle = null;
        }
    }
}

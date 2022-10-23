namespace MyTemplate.Persistence.MongoDb.Context.EntitiesConfigurations;

internal abstract class BaseSerializationMapping<T> : IMongoSerializationMapping
{
    public BaseSerializationMapping()
    {
        ClassMap = x => x.AutoMap();
    }

    public Action<BsonClassMap<T>> ClassMap { get; protected set; }

    public void Configure()
    {
        if (BsonClassMap.IsClassMapRegistered(typeof(T)))
            return;

        BsonClassMap.RegisterClassMap(ClassMap);
    }
}

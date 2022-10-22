namespace MyTemplate.Persistence.MongoDb.Context.EntitiesConfigurations;

internal class EntitySerializationMapping : BaseSerializationMapping<Entity<Guid>>
{
    public EntitySerializationMapping()
    {
        ClassMap = ConfigureMappings;
    }

    private void ConfigureMappings(BsonClassMap<Entity<Guid>> bsonClassMap)
    {
        bsonClassMap.AutoMap();

        bsonClassMap.MapProperty(x => x.EntityId);
        bsonClassMap.SetIgnoreExtraElements(true);
        bsonClassMap.SetIgnoreExtraElementsIsInherited(true);
    }
}

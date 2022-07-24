namespace MyTemplate.Persistence.MongoDb.Extensions;

internal static class MongoSerializationMappings
{
    public static void Register()
    {
        var type = typeof(IMongoSerializationMapping);

        var mappingTypesInstances = Assembly
            .GetExecutingAssembly()
            .DefinedTypes
            .Where(t =>
                type.IsAssignableFrom(t) &&
                t.IsClass &&
                !t.IsAbstract)
            .Select(Activator.CreateInstance)
            .Cast<IMongoSerializationMapping>()
            .ToList();

        foreach (var instance in mappingTypesInstances)
            instance.Configure();
    }
}

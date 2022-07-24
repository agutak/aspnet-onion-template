namespace MyTemplate.Persistence.MongoDb.Extensions;

public class MongoDbSettings
{
    public const string ConfigSectionName = "MongoDbSettings";

    public string ConnectionString { get; set; } = default!;
    public string DatabaseName { get; set; } = default!;
}

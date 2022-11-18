using System.Reflection;

namespace MyTemplate.Persistence.MsSql.Context;

public class MyTemplateContext : DbContext
{
    public const string DEFAULT_SCHEMA = "dbo";

    public MyTemplateContext(DbContextOptions<MyTemplateContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(DEFAULT_SCHEMA);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}

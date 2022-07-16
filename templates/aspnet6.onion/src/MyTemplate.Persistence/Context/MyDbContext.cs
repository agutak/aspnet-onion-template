using System.Reflection;

namespace MyTemplate.Persistence.MsSql.Context;

public class MyDbContext : DbContext
{
    public const string DEFAULT_SCHEMA = "dbo";

    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(DEFAULT_SCHEMA);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}

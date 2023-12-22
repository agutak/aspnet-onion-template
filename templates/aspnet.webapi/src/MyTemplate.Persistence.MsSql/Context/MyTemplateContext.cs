using System.Reflection;

namespace MyTemplate.Persistence.MsSql.Context;

public class MyTemplateContext : DbContext
{
    public const string DEFAULTSCHEMA = "mytpl";

    public MyTemplateContext(DbContextOptions<MyTemplateContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(DEFAULTSCHEMA);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}

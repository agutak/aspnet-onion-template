using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using MyTemplate.Persistence.MsSql.Context;
using System.Reflection;

namespace MyTemplate.Persistence.MsSql.Migrations;

internal class MyDbContextFactory : IDesignTimeDbContextFactory<MyDbContext>
{
    public MyDbContext CreateDbContext(string[] args)
    {
        var connStr = "Server=.;Initial Catalog=MyDb;Integrated Security=true;";

        if (args is not null && args.Length > 0 && args[0].StartsWith("conn="))
            connStr = args[0][5..];

        var assemblyName = Assembly.GetExecutingAssembly().GetName().Name;

        var optionsBuilder = new DbContextOptionsBuilder<MyDbContext>()
            .UseSqlServer(connStr, opts =>
                opts
                    .MigrationsAssembly(assemblyName)
                    .MigrationsHistoryTable("__EFMigrationsHistory", MyDbContext.DEFAULT_SCHEMA));

        return new MyDbContext(optionsBuilder.Options);
    }
}

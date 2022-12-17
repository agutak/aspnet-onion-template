using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using MyTemplate.Persistence.MsSql.Context;
using System.Reflection;

namespace MyTemplate.Persistence.MsSql.Migrations;

internal class MyTemplateContextFactory : IDesignTimeDbContextFactory<MyTemplateContext>
{
    public MyTemplateContext CreateDbContext(string[] args)
    {
        var connStr = "Server=.;Initial Catalog=MyTemplateDb;Integrated Security=true;";

        if (args is not null && args.Length > 0 && args[0].StartsWith("conn="))
            connStr = args[0][5..];

        var assemblyName = Assembly.GetExecutingAssembly().GetName().Name;

        var optionsBuilder = new DbContextOptionsBuilder<MyTemplateContext>()
            .UseSqlServer(connStr, opts =>
                opts
                    .MigrationsAssembly(assemblyName)
                    .MigrationsHistoryTable("__EFMigrationsHistory", MyTemplateContext.DEFAULT_SCHEMA));

        return new MyTemplateContext(optionsBuilder.Options);
    }
}

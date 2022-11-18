namespace MyTemplate.Persistence.MsSql.Repositories;

internal class UnitOfWork : IUnitOfWork
{
    private readonly MyTemplateContext _dbContext;

    public UnitOfWork(MyTemplateContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task CompleteAsync(CancellationToken cancellation)
    {
        await _dbContext.SaveChangesAsync(cancellation);
    }
}

namespace MyTemplate.Persistence.MsSql.Repositories;

internal class UnitOfWork : IUnitOfWork
{
    private readonly MyDbContext _dbContext;

    public UnitOfWork(MyDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task CompleteAsync(CancellationToken cancellation)
    {
        await _dbContext.SaveChangesAsync(cancellation);
    }
}

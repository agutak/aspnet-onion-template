namespace MyTemplate.Persistence.MsSql.Repositories;

internal class Repository<T> where T : class
{
    protected readonly MyDbContext _dbContext;

    public Repository(MyDbContext dbContext)
    {
        _dbContext = dbContext;
    }
}

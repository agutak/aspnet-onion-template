namespace MyTemplate.Application.Repositories;

public interface IUnitOfWork
{
    Task CompleteAsync(CancellationToken cancellation);
}

namespace Domain.IRepository;

public interface IUnitOfWork
{
	Task<int> SaveChangesAsync(string? userId, CancellationToken cancellationToken = default);
}


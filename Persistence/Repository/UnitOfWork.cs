using Domain.Entities;
using Domain.IRepository;

using Microsoft.EntityFrameworkCore;

namespace Persistence.Repository;

internal sealed class UnitOfWork : IUnitOfWork
{
	private readonly RosaFiestaContext _dbContext;

	public UnitOfWork(RosaFiestaContext dbContext) => _dbContext = dbContext;

	public Task<int> SaveChangesAsync(string? userId, CancellationToken cancellationToken = default)
	{
		var changeTracker = _dbContext.ChangeTracker;

		var operations = new Dictionary<EntityState, Action<object, string?>>
		{
			{ EntityState.Deleted, SoftDelete },
			{ EntityState.Modified, AutoUpdate },
			{ EntityState.Added, CreatedBy }
		};

		foreach (var entity in changeTracker.Entries())
			if (operations.TryGetValue(entity.State, out var operation))
				operation(entity.Entity, userId);

		return _dbContext.SaveChangesAsync(cancellationToken);
	}

	private void SoftDelete(object entity, string? userId)
	{
		if (entity is ISoftDelete softDeleteEntity)
		{
			softDeleteEntity.IsDeleted = true;
			_dbContext.Entry(entity).State = EntityState.Modified;
			AutoUpdate(entity, userId);
		}
	}

	private void AutoUpdate(object entity, string? userId)
	{
		if (entity is IAutoUpdate autoUpdateEntity)
		{
			autoUpdateEntity.UpdatedAt = DateTimeOffset.UtcNow;
			UpdatedBy(entity, userId);
		};
	}

	private void UpdatedBy(object entity, string? userId)
	{
		if (userId != null && entity is IAutoBy autoByEntity)
			autoByEntity.UpdatedBy = userId;
	}

	private void CreatedBy(object entity, string? userId)
	{
		if (userId != null && entity is IAutoBy autoByEntity)
			autoByEntity.CreatedBy = userId;
	}
}
using Domain.Entities.Product.UserInteract;
using Domain.IRepository;

using Microsoft.EntityFrameworkCore;

namespace Persistence.Repository;

internal sealed class ReviewRepository : IReviewRepository
{
	private readonly RosaFiestaContext _context;

	public ReviewRepository(RosaFiestaContext context)
	{
		_context = context;
	}

	public async Task AlredyExistAsync(Guid optionId, string userId, CancellationToken cancellationToken = default)
	{
		bool any = await _context.Reviews.AnyAsync(x => x.OptionId == optionId && x.UserId == userId, cancellationToken);
		if (any)
			throw new Exception("Review already exist");
	}

	public async Task<IEnumerable<ReviewEntity>> GetAllAsync(CancellationToken cancellationToken = default) =>
		await _context.Reviews.ToListAsync(cancellationToken);

	public async Task<ReviewEntity> GetByIdAsync(int reviewId, CancellationToken cancellationToken = default)
	{
		ReviewEntity? review = await _context.Reviews.FirstOrDefaultAsync(x => x.Id == reviewId, cancellationToken);
		if (review == null)
			throw new NullReferenceException(nameof(ReviewEntity));
		return review;
	}

	public void Insert(ReviewEntity review) => _context.Reviews.Add(review);

	public void Update(ReviewEntity review) => _context.Reviews.Update(review);
}
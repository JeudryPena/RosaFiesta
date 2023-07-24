using Domain.Entities.Product.UserInteract;

namespace Domain.IRepository;

public interface IReviewRepository
{
	Task AlredyExistAsync(Guid optionId, string userId, CancellationToken cancellationToken = default);

	Task<IEnumerable<ReviewEntity>> GetAllAsync(Guid optionId, CancellationToken cancellationToken = default);
	Task<ReviewEntity> GetByIdAsync(int reviewId, CancellationToken cancellationToken = default);
	void Insert(ReviewEntity review);
	void Update(ReviewEntity review);
}
using Domain.Entities.Product.UserInteract;

namespace Domain.IRepository;

public interface IReviewRepository
{
	Task<IEnumerable<ReviewEntity>> GetAllAsync(CancellationToken cancellationToken = default);
	Task<ReviewEntity> GetByIdAsync(int reviewId, CancellationToken cancellationToken = default);
	void Insert(ReviewEntity review);
	void Update(ReviewEntity review);
	Task AlredyExistAsync(Guid optionId, string userId, CancellationToken cancellationToken = default);
}
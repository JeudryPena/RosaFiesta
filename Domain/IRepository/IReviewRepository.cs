using Domain.Entities.Product.UserInteract;

namespace Domain.IRepository;

public interface IReviewRepository
{
	Task AlredyExistAsync(Guid optionId, string userId, CancellationToken cancellationToken = default);

	Task<IEnumerable<ReviewEntity>> GetAllAsync(Guid optionId, CancellationToken cancellationToken = default);
	Task<ReviewEntity> GetByIdAsync(int reviewId, CancellationToken cancellationToken = default);
	void Insert(ReviewEntity review);
	void Update(ReviewEntity review);
	
	/// <summary>
	/// Deletes review
	/// </summary>
	/// <param name="review"></param>
	void Delete(ReviewEntity review);
	/// <summary>
	/// Returns reviews with user info
	/// </summary>
	/// <param name="optionId"></param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	Task<IEnumerable<ReviewEntity>> GetAllDetailedAsync(Guid optionId, CancellationToken cancellationToken);

	Task<float> GetTotalReviewsWithDatesAsync(CancellationToken cancellationToken, DateOnly start, DateOnly end);
}
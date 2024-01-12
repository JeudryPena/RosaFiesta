using Contracts.Model.Product.Response;
using Contracts.Model.Product.UserInteract;
using Contracts.Model.Product.UserInteract.Response;

namespace Services.Abstractions;

public interface IReviewService
{
	Task<IEnumerable<ReviewPreviewResponse>> GetAllAsync(Guid optionId, CancellationToken cancellationToken = default);
	Task<ReviewResponse> GetByIdAsync(int reviewId, CancellationToken cancellationToken = default);
	Task CreateAsync(string userId, Guid optionId, ReviewDto reviewDto,
		CancellationToken cancellationToken = default);
	Task UpdateAsync(int reviewId, ReviewDto reviewDto, CancellationToken cancellationToken = default);
	Task DeleteAsync(int reviewId, CancellationToken cancellationToken = default);
	Task<IEnumerable<ReviewResponse>> GetOptionReviews(Guid optionId, CancellationToken cancellationToken = default);
	
	/// <summary>
	/// Returns reviews with user info
	/// </summary>
	/// <param name="optionId"></param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	Task<IEnumerable<DetailedReviewResponse>> GetOptionReviewsDetailedAsync(Guid optionId, CancellationToken cancellationToken);
}
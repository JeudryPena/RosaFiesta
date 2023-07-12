using Contracts.Model.Product.UserInteract;
using Contracts.Model.Product.UserInteract.Response;

namespace Services.Abstractions;

public interface IReviewService
{
	Task<IEnumerable<ReviewResponse>> GetAllAsync(CancellationToken cancellationToken = default);
	Task<ReviewResponse> GetByIdAsync(int reviewId, CancellationToken cancellationToken = default);
	Task<ReviewResponse> CreateAsync(string userId, Guid optionId, ReviewDto reviewDto,
		CancellationToken cancellationToken = default);
	Task<ReviewResponse> UpdateAsync(int reviewId, ReviewDto reviewDto, CancellationToken cancellationToken = default);
	Task DeleteAsync(int reviewId, CancellationToken cancellationToken = default);
}
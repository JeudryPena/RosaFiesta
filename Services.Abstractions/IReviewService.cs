using Contracts.Model.Product;
using Contracts.Model.Product.Response;

namespace Services.Abstractions;

public interface IReviewService
{
    Task<IEnumerable<ReviewResponse>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<ReviewResponse> GetByIdAsync(Guid reviewId, CancellationToken cancellationToken = default);
    Task<ReviewResponse> CreateAsync(string userId, Guid productCode, ReviewDto reviewDto,
        CancellationToken cancellationToken = default);
    Task<ReviewResponse> UpdateAsync(Guid reviewId, ReviewDto reviewDto, CancellationToken cancellationToken = default);
    Task DeleteAsync(Guid reviewId, CancellationToken cancellationToken = default);
}
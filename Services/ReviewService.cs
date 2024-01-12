using Contracts.Model.Product.Response;
using Contracts.Model.Product.UserInteract;
using Contracts.Model.Product.UserInteract.Response;

using Domain.Entities.Product.UserInteract;
using Domain.IRepository;

using Mapster;

using Services.Abstractions;

namespace Services;

internal sealed class ReviewService : IReviewService
{
	private readonly IRepositoryManager _repositoryManager;

	public ReviewService(IRepositoryManager repositoryManager)
	{
		_repositoryManager = repositoryManager;
	}

	public async Task<IEnumerable<ReviewPreviewResponse>> GetAllAsync(Guid optionId, CancellationToken cancellationToken = default)
	{
		IEnumerable<ReviewEntity> reviews = await _repositoryManager.ReviewRepository.GetAllAsync(optionId, cancellationToken);
		var reviewResponse = reviews.Adapt<IEnumerable<ReviewPreviewResponse>>();
		return reviewResponse;
	}

	public async Task<IEnumerable<ReviewResponse>> GetOptionReviews(Guid optionId, CancellationToken cancellationToken = default)
	{
		IEnumerable<ReviewEntity> reviews = await _repositoryManager.ReviewRepository.GetAllAsync(optionId, cancellationToken);
		var reviewResponse = reviews.Adapt<IEnumerable<ReviewResponse>>();
		return reviewResponse;
	}

	/// <summary>
	/// Returns reviews with user info
	/// </summary>
	/// <param name="optionId"></param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	public async Task<IEnumerable<DetailedReviewResponse>> GetOptionReviewsDetailedAsync(Guid optionId, CancellationToken cancellationToken)
	{
		IEnumerable<ReviewEntity> reviews = await _repositoryManager.ReviewRepository.GetAllDetailedAsync(optionId, cancellationToken);
    	var reviewResponse = reviews.Adapt<IEnumerable<DetailedReviewResponse>>();
    	return reviewResponse;	
	}

	public async Task<ReviewResponse> GetByIdAsync(int reviewId, CancellationToken cancellationToken = default)
	{
		ReviewEntity review = await _repositoryManager.ReviewRepository.GetByIdAsync(reviewId, cancellationToken);
		var reviewResponse = review.Adapt<ReviewResponse>();
		return reviewResponse;
	}

	public async Task CreateAsync(string userId, Guid optionId, ReviewDto reviewDto,
		CancellationToken cancellationToken = default)
	{
		var review = reviewDto.Adapt<ReviewEntity>();
		await _repositoryManager.ReviewRepository.AlredyExistAsync(optionId, userId, cancellationToken);
		review.OptionId = optionId;
		review.UserId = userId;
		_repositoryManager.ReviewRepository.Insert(review);
		await _repositoryManager.UnitOfWork.SaveChangesAsync(userId, cancellationToken);
	}

	public async Task UpdateAsync(int reviewId, ReviewDto reviewDto, CancellationToken cancellationToken = default)
	{
		ReviewEntity review = await _repositoryManager.ReviewRepository.GetByIdAsync(reviewId, cancellationToken);
		review = reviewDto.Adapt(review);
		_repositoryManager.ReviewRepository.Update(review);
		await _repositoryManager.UnitOfWork.SaveChangesAsync(null, cancellationToken);
	}

	public async Task DeleteAsync(int reviewId, CancellationToken cancellationToken = default)
	{
		ReviewEntity review = await _repositoryManager.ReviewRepository.GetByIdAsync(reviewId, cancellationToken);
		_repositoryManager.ReviewRepository.Delete(review);
		await _repositoryManager.UnitOfWork.SaveChangesAsync(null, cancellationToken);
	}
}
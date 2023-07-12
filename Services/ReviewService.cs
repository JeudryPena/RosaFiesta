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

	public async Task<IEnumerable<ReviewResponse>> GetAllAsync(CancellationToken cancellationToken = default)
	{
		IEnumerable<ReviewEntity> reviews = await _repositoryManager.ReviewRepository.GetAllAsync(cancellationToken);
		var reviewResponse = reviews.Adapt<IEnumerable<ReviewResponse>>();
		return reviewResponse;
	}

	public async Task<ReviewResponse> GetByIdAsync(int reviewId, CancellationToken cancellationToken = default)
	{
		ReviewEntity review = await _repositoryManager.ReviewRepository.GetByIdAsync(reviewId, cancellationToken);
		var reviewResponse = review.Adapt<ReviewResponse>();
		return reviewResponse;
	}

	public async Task<ReviewResponse> CreateAsync(string userId, Guid optionId, ReviewDto reviewDto,
		CancellationToken cancellationToken = default)
	{
		var review = reviewDto.Adapt<ReviewEntity>();
		await _repositoryManager.ReviewRepository.AlredyExistAsync(optionId, userId, cancellationToken);
		review.OptionId = optionId;
		_repositoryManager.ReviewRepository.Insert(review);
		await _repositoryManager.UnitOfWork.SaveChangesAsync(null, cancellationToken);
		var reviewResponse = review.Adapt<ReviewResponse>();
		return reviewResponse;
	}

	public async Task<ReviewResponse> UpdateAsync(int reviewId, ReviewDto reviewDto, CancellationToken cancellationToken = default)
	{
		ReviewEntity review = await _repositoryManager.ReviewRepository.GetByIdAsync(reviewId, cancellationToken);
		review = reviewDto.Adapt(review);
		_repositoryManager.ReviewRepository.Update(review);
		await _repositoryManager.UnitOfWork.SaveChangesAsync(null, cancellationToken);
		var reviewResponse = review.Adapt<ReviewResponse>();
		return reviewResponse;
	}

	public async Task DeleteAsync(int reviewId, CancellationToken cancellationToken = default)
	{
		ReviewEntity review = await _repositoryManager.ReviewRepository.GetByIdAsync(reviewId, cancellationToken);
		_repositoryManager.ReviewRepository.Update(review);
		await _repositoryManager.UnitOfWork.SaveChangesAsync(null, cancellationToken);
	}
}
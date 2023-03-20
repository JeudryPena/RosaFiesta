using Contracts.Model.Product;
using Contracts.Model.Product.Response;
using Domain.Entities.Product.Helpers;
using Domain.Entities.Product.UserInteract;
using Domain.IRepository;
using Mapster;
using Services.Abstractions;

namespace Services;

internal sealed class ReviewService: IReviewService
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

    public async Task<ReviewResponse> GetByIdAsync(Guid reviewId, CancellationToken cancellationToken = default)
    {
        ReviewEntity review = await _repositoryManager.ReviewRepository.GetByIdAsync(reviewId, cancellationToken);
        var reviewResponse = review.Adapt<ReviewResponse>();
        return reviewResponse;
    }

    public async Task<ReviewResponse> CreateAsync(string userId, Guid productCode, ReviewDto reviewDto,
        CancellationToken cancellationToken = default)
    {
        var user = await _repositoryManager.UserRepository.GetByIdAsync(userId, cancellationToken);
        

        var review = reviewDto.Adapt<ReviewEntity>();
        review.Id = Guid.NewGuid();

        _repositoryManager.ReviewRepository.Insert(review);
        await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        var reviewResponse = review.Adapt<ReviewResponse>();
        return reviewResponse;
    }

    public async Task<ReviewResponse> UpdateAsync(Guid reviewId, ReviewDto reviewDto, CancellationToken cancellationToken = default)
    {
        ReviewEntity review = await _repositoryManager.ReviewRepository.GetByIdAsync(reviewId, cancellationToken);
        review.ReviewDescription = reviewDto.ReviewDescription;
        review.ReviewRating = reviewDto.ReviewRating;
        review.ReviewUpdateDate = DateTimeOffset.Now;
        review.ReviewTittle = reviewDto.ReviewTittle;

        _repositoryManager.ReviewRepository.Update(review);
        await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        var reviewResponse = review.Adapt<ReviewResponse>();
        return reviewResponse;
    }

    public async Task DeleteAsync(Guid reviewId, CancellationToken cancellationToken = default)
    {
        ReviewEntity review = await _repositoryManager.ReviewRepository.GetByIdAsync(reviewId, cancellationToken);
        _repositoryManager.ReviewRepository.Delete(review);
        await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
    }
}
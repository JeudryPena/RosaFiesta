using Domain.Entities.Product.UserInteract;

namespace Domain.IRepository;

public interface IReviewRepository
{
    Task<IEnumerable<ReviewEntity>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<ReviewEntity> GetByIdAsync(Guid reviewId, CancellationToken cancellationToken = default);
    void Insert(ReviewEntity review);
    void Update(ReviewEntity review);
    void Delete(ReviewEntity review);
    
}
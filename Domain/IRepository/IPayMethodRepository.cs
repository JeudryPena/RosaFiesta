using Domain.Entities.Product.UserInteract;

namespace Domain.IRepository;

public interface IPayMethodRepository
{
    Task<PayMethodEntity> GetByIdAsync(Guid payMethodId, CancellationToken cancellationToken);
}
using Domain.Entities.Product.UserInteract;
using Domain.Entities.Security;

namespace Domain.IRepository;

public interface IPayMethodRepository
{
	Task<PayMethodEntity> GetByIdAsync(Guid payMethodId, CancellationToken cancellationToken);
	Task<IEnumerable<PayMethodEntity>> GetByUserIdAsync(string userId, CancellationToken cancellationToken);
	Guid? GetDefaultPaymentId(string userId, CancellationToken cancellationToken);
	Task<UserEntity> GetUserByDefaultPayment(string userId, Guid paymentId,
		CancellationToken cancellationToken = default);
}
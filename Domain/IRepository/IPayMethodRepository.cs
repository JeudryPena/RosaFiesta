using Domain.Entities.Product.UserInteract;
using Domain.Entities.Security;

namespace Domain.IRepository;

public interface IPayMethodRepository
{
	void Delete(PayMethodEntity payment);
	Task<PayMethodEntity> GetByIdAsync(Guid payMethodId, CancellationToken cancellationToken);
	Task<IEnumerable<PayMethodEntity>> GetByUserIdAsync(string userId, CancellationToken cancellationToken);
	Guid? GetDefaultPaymentId(string userId, CancellationToken cancellationToken);
	Task<UserEntity> GetUserByDefaultPayment(string userId, Guid paymentId,
		CancellationToken cancellationToken = default);
	void Update(PayMethodEntity payment);
	void Create(PayMethodEntity payment);
}
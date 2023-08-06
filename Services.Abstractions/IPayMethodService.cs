using Contracts.Model.Product.UserInteract;
using Contracts.Model.Security.Response;

namespace Services.Abstractions;

public interface IPayMethodService
{
	Task<IEnumerable<PaymentsPreviewResponse>> GetByUserIdAsync(string userId, CancellationToken cancellationToken = default);
	Task<PaymentResponse> GetByIdAsync(Guid paymentId, CancellationToken cancellationToken = default);
	Task DeleteAsync(Guid paymentId, CancellationToken cancellationToken);
	Task MakePaymentDefaultAsync(Guid paymentId, string userId, CancellationToken cancellationToken = default);
	Task CreateAsync(PayMethodDto payMethodDto, string userId, CancellationToken cancellationToken = default);
}
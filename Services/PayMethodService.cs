using Contracts.Model.Security.Response;

using Domain.Entities.Product.UserInteract;
using Domain.Entities.Security;
using Domain.IRepository;

using Mapster;

using Services.Abstractions;

namespace Services;

public class PayMethodService : IPayMethodService
{
	private readonly IRepositoryManager _repositoryManager;

	public PayMethodService(IRepositoryManager repositoryManager)
	{
		_repositoryManager = repositoryManager;
	}

	public async Task<IEnumerable<PaymentsPreviewResponse>> GetByUserIdAsync(string userId, CancellationToken cancellationToken = default)
	{
		IEnumerable<PayMethodEntity> payments = await _repositoryManager.PayMethodRepository.GetByUserIdAsync(userId, cancellationToken);
		ICollection<PaymentsPreviewResponse> paymentsPreviewResponse = payments.Adapt<ICollection<PaymentsPreviewResponse>>();
		if (_repositoryManager.PayMethodRepository.GetDefaultPaymentId(userId, cancellationToken) is { } defaultPaymentId)
		{
			var defaultPayment = paymentsPreviewResponse.FirstOrDefault(p => p.Id == defaultPaymentId);
			if (defaultPayment != null)
				defaultPayment.IsDefault = true;
		}
		return paymentsPreviewResponse;
	}

	public async Task<PaymentResponse> GetByIdAsync(Guid paymentId, CancellationToken cancellationToken = default)
	{
		PayMethodEntity payment = await _repositoryManager.PayMethodRepository.GetByIdAsync(paymentId, cancellationToken);
		PaymentResponse paymentResponse = payment.Adapt<PaymentResponse>();
		return paymentResponse;
	}

	public async Task DeleteAsync(Guid paymentId, CancellationToken cancellationToken)
	{
		PayMethodEntity payment = _repositoryManager.PayMethodRepository.GetByIdAsync(paymentId, cancellationToken).Result;
		payment.IsDeleted = true;
		_repositoryManager.PayMethodRepository.Update(payment);
		await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
	}

	public async Task MakePaymentDefaultAsync(Guid paymentId, string userId, CancellationToken cancellationToken = default)
	{
		UserEntity user = await _repositoryManager.PayMethodRepository.GetUserByDefaultPayment(userId, paymentId, cancellationToken);
		user.DefaultPayMethodId = paymentId;
		_repositoryManager.UserRepository.Update(user);
		await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
	}
}
using Contracts.Model.Product;
using Contracts.Model.Product.Response;

using Domain.Entities.Product;
using Domain.IRepository;

using Mapster;

using Services.Abstractions;

namespace Services;

internal sealed class DiscountService : IDiscountService
{
	private readonly IRepositoryManager _repositoryManager;

	public DiscountService(IRepositoryManager repositoryManager)
	{
		_repositoryManager = repositoryManager;
	}

	public async Task<IEnumerable<ManagementDiscountsResponse>> ManagementGetAllAsync(CancellationToken cancellationToken = default)
	{
		IEnumerable<DiscountEntity> discounts = await _repositoryManager.DiscountRepository.GetAllAsync(cancellationToken);
		var discountResponse = discounts.Adapt<IEnumerable<ManagementDiscountsResponse>>();
		return discountResponse;
	}

	public async Task<ManagementDiscountsResponse> GetManagementDiscountAsync(string code, CancellationToken cancellationToken = default)
	{
		DiscountEntity discount = await _repositoryManager.DiscountRepository.GetByIdAsync(code, cancellationToken);
		var discountResponse = discount.Adapt<ManagementDiscountsResponse>();
		return discountResponse;
	}

	public async Task<DiscountResponse> GetDiscountAsync(string discountId,
		CancellationToken cancellationToken = default)
	{
		DiscountEntity discount = await _repositoryManager.DiscountRepository.GetByIdAsync(discountId, cancellationToken);
		var discountResponse = discount.Adapt<DiscountResponse>();
		return discountResponse;
	}

	public async Task CreateDiscountAsync(string userId, DiscountDto discount, CancellationToken cancellationToken = default)
	{
		var discountEntity = discount.Adapt<DiscountEntity>();
		discountEntity.ProductsDiscounts = discount.ProductsDiscounts.Select(d => new ProductsDiscountsEntity()
		{
			Code = discountEntity.Code,
			ProductId = d.ProductCode ?? null,
			OptionId = d.OptionId ?? null,
			CreatedAt = DateTimeOffset.UtcNow
		}).ToList();
		discountEntity.CreatedBy = userId;
		_repositoryManager.DiscountRepository.Insert(discountEntity);
		await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
	}

	public async Task UpdateDiscountAsync(string userId, string discountId,
		DiscountDto discountDto,
		CancellationToken cancellationToken = default)
	{
		DiscountEntity discount = await _repositoryManager.DiscountRepository.GetByIdAsync(discountId, cancellationToken);
		discount.Adapt(discountDto);
		discount.UpdatedAt = DateTimeOffset.UtcNow;
		discount.UpdatedBy = userId;
		_repositoryManager.DiscountRepository.Update(discount);
		await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
	}

	public async Task DeleteDiscountAsync(string userId, string discountId,
		CancellationToken cancellationToken = default)
	{
		DiscountEntity discount = await _repositoryManager.DiscountRepository.GetDiscountAsync(discountId, cancellationToken);
		discount.IsDeleted = true;
		discount.UpdatedAt = DateTimeOffset.UtcNow;
		discount.UpdatedBy = userId;
		_repositoryManager.DiscountRepository.Update(discount);
		await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
	}
}
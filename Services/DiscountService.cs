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
		if (discount.ProductsDiscounts != null)
			discountEntity.ProductsDiscounts = discount.ProductsDiscounts.Select(d => new ProductsDiscountsEntity()
			{
				Code = discountEntity.Code,
				OptionId = d.OptionId,
			}).ToList();
		discountEntity.CreatedBy = userId;
		_repositoryManager.DiscountRepository.Insert(discountEntity);
		await _repositoryManager.UnitOfWork.SaveChangesAsync(userId, cancellationToken);
	}

	public async Task UpdateDiscountAsync(string userId, string discountId,
		DiscountDto discountDto,
		CancellationToken cancellationToken = default)
	{
		DiscountEntity discount = await _repositoryManager.DiscountRepository.GetByIdAsync(discountId, cancellationToken);
		discount = discountDto.Adapt(discount);
		if (discount.ProductsDiscounts != null)
		{
			if (discountDto.ProductsDiscounts == null)
				discount.ProductsDiscounts.ToList().ForEach(d => d.IsDeleted = true);
			else
			{
				foreach (var productDiscount in discount.ProductsDiscounts)
				{
					if (!discountDto.ProductsDiscounts.Any(d => d.OptionId == productDiscount.OptionId))
						discount.ProductsDiscounts.Remove(productDiscount);
				}
			}
		}
		_repositoryManager.DiscountRepository.Update(discount);
		await _repositoryManager.UnitOfWork.SaveChangesAsync(userId, cancellationToken);
	}

	public async Task DeleteDiscountAsync(string userId, string discountId,
		CancellationToken cancellationToken = default)
	{
		DiscountEntity discount = await _repositoryManager.DiscountRepository.GetDiscountAsync(discountId, cancellationToken);
		_repositoryManager.DiscountRepository.Delete(discount);
		await _repositoryManager.UnitOfWork.SaveChangesAsync(userId, cancellationToken);
	}

	public async Task DeleteDiscountProductsAsync(string userId, string code, int? optionId, CancellationToken cancellationToken = default)
	{
		DiscountEntity discount = await _repositoryManager.DiscountRepository.GetByIdAsync(code, cancellationToken);
		if (discount.ProductsDiscounts == null)
			throw new Exception("Discount products not found");
		else if (optionId != null)
		{
			var productDiscount = discount.ProductsDiscounts.FirstOrDefault(d => d.OptionId == optionId) ?? throw new Exception("Discount product not found");
			discount.ProductsDiscounts.Remove(productDiscount);
		}
		else
		{
			discount.ProductsDiscounts = new List<ProductsDiscountsEntity>();
		}
		_repositoryManager.DiscountRepository.Delete(discount);
		await _repositoryManager.UnitOfWork.SaveChangesAsync(userId, cancellationToken);
	}
}
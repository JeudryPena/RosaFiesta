using System.Web;
using Contracts.Model.Product;
using Contracts.Model.Product.Response;

using Domain.Entities.Product;
using Domain.IRepository;

using Mapster;
using Messaging;
using Microsoft.AspNetCore.WebUtilities;
using Services.Abstractions;

namespace Services;

internal sealed class DiscountService : IDiscountService
{
	private readonly IRepositoryManager _repositoryManager;
	private readonly IEmailSender _emailSender;

	public DiscountService(IRepositoryManager repositoryManager, IEmailSender emailSender)
	{
		_repositoryManager = repositoryManager;
		_emailSender = emailSender;
	}

	public async Task<IEnumerable<ManagementDiscountsResponse>> ManagementGetAllAsync(CancellationToken cancellationToken = default)
	{
		IEnumerable<DiscountEntity> discounts = await _repositoryManager.DiscountRepository.GetAllAsync(cancellationToken);
		foreach (var discount in discounts)
		{
			discount.CreatedBy = await _repositoryManager.UserRepository.GetUserName(discount.CreatedBy, cancellationToken);
			if (discount.UpdatedBy != null)
				discount.UpdatedBy = await _repositoryManager.UserRepository.GetUserName(discount.UpdatedBy, cancellationToken);
		}
		IEnumerable<ManagementDiscountsResponse> discountResponse = discounts.Adapt<IEnumerable<ManagementDiscountsResponse>>();
		return discountResponse;
	}
	
	/// <summary>
	/// Get all discounted products with highest discount
	/// </summary>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	public async Task<DiscountResponse> GetHotOffersAsync(CancellationToken cancellationToken)
	{
		DiscountEntity discount = await _repositoryManager.DiscountRepository.GetHotOffersAsync(cancellationToken);
		DiscountResponse discountResponse = discount.Adapt<DiscountResponse>();
		return discountResponse;
	}

	public async Task<ManagementDiscountsResponse> GetManagementDiscountAsync(Guid discountId, CancellationToken cancellationToken = default)
	{
		DiscountEntity discount = await _repositoryManager.DiscountRepository.GetByIdAsync(discountId, cancellationToken);
		var discountResponse = discount.Adapt<ManagementDiscountsResponse>();
		discountResponse.CreatedBy = await _repositoryManager.UserRepository.GetUserName(discount.CreatedBy, cancellationToken);
		if (discount.UpdatedBy != null)
			discountResponse.UpdatedBy = await _repositoryManager.UserRepository.GetUserName(discount.UpdatedBy, cancellationToken);
		return discountResponse;
	}

	public async Task<DiscountResponse?> GetOptionDiscount(Guid optionId,
		CancellationToken cancellationToken = default)
	{
		DiscountEntity? discount = await _repositoryManager.DiscountRepository.GetOptionDiscountAsync(optionId, cancellationToken);
		if (discount == null)
			return null;
		var discountResponse = discount.Adapt<DiscountResponse>();
		return discountResponse;
	}

	public async Task CreateDiscountAsync(string userId, DiscountDto discount, CancellationToken cancellationToken = default)
	{
		var discountEntity = discount.Adapt<DiscountEntity>();
		_repositoryManager.DiscountRepository.Insert(discountEntity);
		await _repositoryManager.UnitOfWork.SaveChangesAsync(userId, cancellationToken);
		if (discount.ProductsDiscounts is { Count: > 0 })
		{
			DiscountEntity newDiscountEntity =
				await _repositoryManager.DiscountRepository.GetByIdAsync(discountEntity.Id, cancellationToken);
			await PromoteDiscountEmailAsync(newDiscountEntity, cancellationToken);
		}
	}

	public async Task UpdateDiscountAsync(string userId, Guid discountId,
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

	public async Task DeleteDiscountAsync(string userId, Guid discountId,
		CancellationToken cancellationToken = default)
	{
		DiscountEntity discount = await _repositoryManager.DiscountRepository.GetDiscountAsync(discountId, cancellationToken);
		_repositoryManager.DiscountRepository.Delete(discount);
		await _repositoryManager.UnitOfWork.SaveChangesAsync(userId, cancellationToken);
	}

	public async Task DeleteDiscountProductsAsync(string userId, Guid discountId, Guid? optionId, CancellationToken cancellationToken = default)
	{
		DiscountEntity discount = await _repositoryManager.DiscountRepository.GetByIdAsync(discountId, cancellationToken);
		if (discount.ProductsDiscounts == null)
			throw new Exception("Discount products not found");
		if (optionId != null)
		{
			var productDiscount = discount.ProductsDiscounts.FirstOrDefault(d => d.OptionId == optionId) ?? throw new Exception("Discount product not found");
			discount.ProductsDiscounts.Remove(productDiscount);
		}
		else
		{
			discount.ProductsDiscounts.Clear();
		}
		_repositoryManager.DiscountRepository.Update(discount);
		await _repositoryManager.UnitOfWork.SaveChangesAsync(userId, cancellationToken);
	}
	
	public async Task PromoteDiscountEmailAsync(DiscountEntity discount, CancellationToken cancellationToken)
	{
		List<string> htmlButtons = new List<string>();
		foreach (var option in discount.ProductsDiscounts)
		{
			var param = new Dictionary<string, string?>
			{
				{"optionId", option.OptionId.ToString()},
				{"productId", option.Option.ProductId.ToString()}
			};
		
			var callback = QueryHelpers.AddQueryString("http://localhost:4200/admin/dashboard/orders", param);
		
			htmlButtons.Add($"<a href='{callback}' style='background-color: #4CAF50; border: none; color: white; padding: 15px 32px; text-align: center; text-decoration: none; display: inline-block; font-size: 16px;'>" +
			                $"<p>{option.Option.Title} </p>" +
			                $"<div style='display: flex; gap: 6px'>" +
			                $"<p style='margin-right: 4px; color: #EB001B; text-decoration: line-through'>USD${option.Option.Price}</p>" +
			                $"<p style='color: #0D6EFD; margin-right: 4px'>USD${option.Option.Price - (option.Option.Price * discount.Value / 100)}</p>" +
			                $"<p style='color: #0D6EFD'>({discount.Value}%)</p>" +
			                $"</div>" +
			                $"</a>"
			                );
		}
		
		List<string> emails = await _repositoryManager.UserRepository.GetAllUsersWithPromoEnabled(cancellationToken);
		var message = new EmailMessage(emails, "Descuentos de Productos Decorativos", $"Aprovecha la oferta con RosaFiesta, los siguientes descuentos estan disponibles por tiempo limitado:  <br/> <br/> {string.Join("<br/> <br/>", htmlButtons)}", null);
		await _emailSender.SendEmailAsync(message);
	}
}
using Contracts.Model.Enterprise;
using Contracts.Model.Enterprise.Response;
using Contracts.Model.Product.Response;
using Domain.Entities.Enterprise;
using Domain.Entities.Product;
using Domain.Entities.Product.Helpers;
using Domain.Entities.Product.UserInteract;
using Domain.IRepository;

using Mapster;

using Services.Abstractions;

namespace Services;

internal sealed class QuoteService : IQuoteService
{
	private readonly IRepositoryManager _repositoryManager;

	public QuoteService(IRepositoryManager repositoryManager)
	{
		_repositoryManager = repositoryManager;
	}

	public async Task<IEnumerable<QuotePreviewResponse>> GetQuotesAsync(CancellationToken cancellationToken = default)
	{
		IEnumerable<QuoteEntity> quotes = await _repositoryManager.QuoteRepository.GetQuotesAsync(cancellationToken);
		IEnumerable<QuotePreviewResponse> quotePreviewResponses = quotes.Adapt<IEnumerable<QuotePreviewResponse>>();
		return quotePreviewResponses;
	}

	public async Task<IEnumerable<QuotePreviewResponse>> GetQuotesByUserIdAsync(string userId, CancellationToken cancellationToken = default)
	{
		IEnumerable<QuoteEntity> quotes = await _repositoryManager.QuoteRepository.GetQuotesByUserIdAsync(userId, cancellationToken);
		IEnumerable<QuotePreviewResponse> quotePreviewResponses = quotes.Adapt<IEnumerable<QuotePreviewResponse>>();
		return quotePreviewResponses;
	}

	public async Task<QuoteResponse> GetQuoteAsync(Guid id, CancellationToken cancellationToken = default)
	{
		QuoteEntity quote = await _repositoryManager.QuoteRepository.GetQuoteAsync(id, cancellationToken);
		QuoteResponse quoteResponse = quote.Adapt<QuoteResponse>();
		return quoteResponse;
	}

	public async Task CreateQuoteAsync(QuoteDto quoteDto, CancellationToken cancellationToken)
	{
		QuoteEntity quote = quoteDto.Adapt<QuoteEntity>();
		quote.Id = Guid.NewGuid();
		_repositoryManager.QuoteRepository.CreateAsync(quote, cancellationToken);
		OrderEntity order = new()
		{
			QuoteId = quote.Id,
			Id = Guid.NewGuid(),
			Address = new AddressEntity()
			{
				Id = Guid.NewGuid(),
				Email = quoteDto.Email,
				CustomerName = quoteDto.FullName
			},
			Status = OrderStatusType.Cotización
		};
		_repositoryManager.OrderRepository.CreateAsync(order);
		await _repositoryManager.UnitOfWork.SaveChangesAsync(null, cancellationToken);
	}

	public async Task<QuoteResponse> CreateUserQuoteAsync(string userId, QuoteDto quoteDto, CancellationToken cancellationToken)
	{
		QuoteEntity quote = quoteDto.Adapt<QuoteEntity>();
		quote.UserId = userId;
		_repositoryManager.QuoteRepository.CreateAsync(quote, cancellationToken);
		await _repositoryManager.UnitOfWork.SaveChangesAsync(userId, cancellationToken);
		QuoteResponse quoteResponse = quote.Adapt<QuoteResponse>();
		return quoteResponse;
	}

	public async Task<QuoteResponse> UpdateQuoteAsync(Guid id, QuoteDto quoteDto, string userId,
		CancellationToken cancellationToken)
	{
		QuoteEntity quote = await _repositoryManager.QuoteRepository.GetQuoteByUserIdAsync(id, userId, cancellationToken);
		quoteDto.Adapt(quote);
		_repositoryManager.QuoteRepository.Update(quote);
		await _repositoryManager.UnitOfWork.SaveChangesAsync(userId, cancellationToken);
		QuoteResponse quoteResponse = quote.Adapt<QuoteResponse>();
		return quoteResponse;
	}

	public async Task DeleteQuoteAsync(Guid id, string userId, CancellationToken cancellationToken = default)
	{
		QuoteEntity quote = await _repositoryManager.QuoteRepository.GetQuoteByUserIdAsync(id, userId, cancellationToken);
		_repositoryManager.QuoteRepository.Delete(quote);
		await _repositoryManager.UnitOfWork.SaveChangesAsync(userId, cancellationToken);
	}

	public async Task<int> GetQuotesCountAsync(CancellationToken cancellationToken)
	{
		int count = await _repositoryManager.QuoteRepository.GetQuotesCountAsync(cancellationToken);
		return count;
	}

	public async Task OficializeQuoteAsync(OficializeQuoteDto oficializeQuoteDto, CancellationToken cancellationToken)
	{
		QuoteEntity quote = await _repositoryManager.QuoteRepository.GetQuoteAsync(oficializeQuoteDto.Id, cancellationToken);
		quote.Order.Address.PhoneNumber = oficializeQuoteDto.Phone;
		quote.Order.CurrencyCode = "USD";
		quote.Order.Address.Address = oficializeQuoteDto.Address;
		quote.Order.Address.Location = oficializeQuoteDto.Location;
		quote.Order.Address.Province = oficializeQuoteDto.Province;
		quote.Order.Address.PostalCode = oficializeQuoteDto.PostalCode;
		quote.EventDate = oficializeQuoteDto.EventDate;
		quote.Order.Status = OrderStatusType.Oficializado;
		quote.Order.Shipping = oficializeQuoteDto.Shipping;
		quote.Order.Details = new List<PurchaseDetailEntity>();

		IList<PurchaseDetailEntity> details = new List<PurchaseDetailEntity>();
		foreach (OficializeItemsDto detail in oficializeQuoteDto.Products.ToList())
		{
			PurchaseDetailEntity newDetail = new PurchaseDetailEntity();
			newDetail.Id = Guid.NewGuid();
			newDetail.ProductId = detail.ProductId;
			newDetail.OrderId = quote.Order.Id;
			Guid? warrantyId = await _repositoryManager.WarrantyRepository.GetIdByProductId(newDetail.ProductId, cancellationToken);
			if (warrantyId != null)
				newDetail.WarrantyId = warrantyId;
			foreach (OficializeItemsDto optionPurchase in oficializeQuoteDto.Products.Where(x => x.ProductId == detail.ProductId).ToList())
			{
				PurchaseDetailOptions purchaseDetailOptions = new();
				OptionEntity option = await _repositoryManager.ProductRepository.GetOptionByIdAsync(optionPurchase.OptionId, cancellationToken);
				if (option.QuantityAvailable < optionPurchase.Quantity)
					throw new Exception("You can't add more than the quantity available");
				option.QuantityAvailable -= optionPurchase.Quantity;
				_repositoryManager.ProductRepository.UpdateOption(option);
				purchaseDetailOptions.Title = option.Title;
				DiscountEntity? discount = await _repositoryManager.DiscountRepository.GetOptionDiscountAsync(option.Id, cancellationToken);
				purchaseDetailOptions.Quantity = optionPurchase.Quantity;
				purchaseDetailOptions.OptionId = option.Id;
				purchaseDetailOptions.DetailId = newDetail.Id;
				purchaseDetailOptions.UnitPrice = option.Price;
				if (discount != null)
				{
					double value = option.Price * discount.Value / 100;
					purchaseDetailOptions.UnitPrice -= value;
					purchaseDetailOptions.Discounted = value;
				}
				purchaseDetailOptions.IsService = await _repositoryManager.ProductRepository.IsService(option.ProductId, cancellationToken);
				newDetail.PurchaseOptions.Add(purchaseDetailOptions);
			}
			await _repositoryManager.PurchaseDetailRepository.CreateAsync(newDetail);
			await _repositoryManager.UnitOfWork.SaveChangesAsync(null, cancellationToken);
		}
		_repositoryManager.OrderRepository.Update(quote.Order);
		await _repositoryManager.UnitOfWork.SaveChangesAsync(null, cancellationToken);
		
		_repositoryManager.QuoteRepository.Update(quote);
		await _repositoryManager.UnitOfWork.SaveChangesAsync(null, cancellationToken);
	}
}
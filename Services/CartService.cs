using Contracts.Model.Product.Response;
using Contracts.Model.Product.UserInteract;

using Domain.Entities.Product;
using Domain.Entities.Product.UserInteract;
using Domain.IRepository;

using Mapster;

using Services.Abstractions;

namespace Services;

internal sealed class CartService : ICartService
{
	private readonly IRepositoryManager _repositoryManager;

	public CartService(IRepositoryManager repositoryManager)
	{
		_repositoryManager = repositoryManager;
	}

	public async Task<CartResponse> GetByIdAsync(string id, CancellationToken cancellationToken = default)
	{
		CartEntity cart = await _repositoryManager.CartRepository.GetByIdAsync(id, cancellationToken);
		var cartResponse = cart.Adapt<CartResponse>();
		return cartResponse;
	}

	public async Task AddPackToCartAsync(string userId, Guid optionId, List<PurchaseDetailDto> cartItems,
		CancellationToken cancellationToken = default)
	{
		CartEntity cart = await _repositoryManager.CartRepository.GetByIdAsync(userId, cancellationToken);
		cart.Details ??= new List<PurchaseDetailEntity>();
		foreach (var cartItem in cartItems)
		{
			var product = await _repositoryManager.ProductRepository.GetProductDetail(cartItem.ProductId, cartItem.OptionId, cancellationToken);
			var productOption = product.Options[0];
			if (productOption.QuantityAvailable < cartItem.Quantity + cart.Details.Where(cd => cd.ProductId == cartItem.ProductId).Sum(cd => cd.PurchaseOptions.Sum(po => po.Quantity)))
				throw new Exception("Not enough quantity available");
			PurchaseDetailEntity? cartItemEntity =
				cart.Details.FirstOrDefault(cp => cp.ProductId == cartItem.ProductId);
			if (cartItemEntity == null)
			{
				cartItemEntity = new PurchaseDetailEntity
				{
					ProductId = cartItem.ProductId,
				};

				cartItemEntity.PurchaseOptions.Add(new PurchaseDetailOptions
				{
					OptionId = cartItem.OptionId,
					Quantity = cartItem.Quantity,
					UnitPrice = productOption.Price
				});

				cart.Details.Add(cartItemEntity);
			}
			else
			{
				var purchaseOption = cartItemEntity.PurchaseOptions.FirstOrDefault(po => po.OptionId == cartItem.OptionId);
				if (purchaseOption == null)
					throw new Exception("Option not found");
				purchaseOption.Quantity += cartItem.Quantity;
			}
		}
		_repositoryManager.CartRepository.UpdateCart(cart);
		await _repositoryManager.UnitOfWork.SaveChangesAsync(userId, cancellationToken);
	}

	public async Task AdjustCartItemQuantityAsync(string userId, Guid detailId, Guid optionId, int adjust, CancellationToken cancellationToken = default)
	{
		PurchaseDetailOptions optionDetail = await _repositoryManager.PurchaseDetailRepository.GetOptionDetailAsync(optionId, detailId, cancellationToken);
		OptionEntity option = await _repositoryManager.ProductRepository.GetOptionByIdAsync(optionId, cancellationToken);
		if (option.QuantityAvailable < optionDetail.Quantity + adjust)
			throw new Exception("Not enough quantity available");
		optionDetail.Quantity = adjust;
		_repositoryManager.CartRepository.UpdateDetailOption(optionDetail);
		await _repositoryManager.UnitOfWork.SaveChangesAsync(userId, cancellationToken);
	}

	public async Task RemoveCartItemAsync(string userId, Guid detailId, Guid? optionId,
		CancellationToken cancellationToken = default)
	{
		CartEntity cart = await _repositoryManager.CartRepository.GetByIdAsync(userId, cancellationToken);
		if (cart.Details == null) throw new Exception("Cart is empty");
		PurchaseDetailEntity cartItem = cart.Details.FirstOrDefault(cp => cp.Id == detailId) ?? throw new Exception("Product not found in cart");
		if (optionId != null || cartItem.PurchaseOptions.LongCount() != 1)
		{
			cartItem.PurchaseOptions.Remove(cartItem.PurchaseOptions.FirstOrDefault(po => po.OptionId == optionId) ?? throw new Exception("Option not found in cart"));
		}
		else
			cart.Details.Remove(cartItem);
		_repositoryManager.CartRepository.UpdateCart(cart);
		await _repositoryManager.UnitOfWork.SaveChangesAsync(userId, cancellationToken);
	}

	public async Task ClearCartAsync(string userId, CancellationToken cancellationToken = default)
	{
		CartEntity cart = await _repositoryManager.CartRepository.GetByIdAsync(userId, cancellationToken);
		if (cart.Details == null) throw new Exception("Cart is empty");
		cart.Details.Clear();
		_repositoryManager.CartRepository.UpdateCart(cart);
		await _repositoryManager.UnitOfWork.SaveChangesAsync(userId, cancellationToken);
	}

	public async Task AddProductToCartAsync(string userId, PurchaseDetailDto cartItem,
		CancellationToken cancellationToken = default)
	{
		CartEntity cart = await _repositoryManager.CartRepository.GetByIdAsync(userId, cancellationToken);
		cart.Details ??= new List<PurchaseDetailEntity>();
		PurchaseDetailEntity? detail = cart.Details.FirstOrDefault(cp => cp.ProductId == cartItem.ProductId);
		if (detail == null)
		{
			double optionPrice = await _repositoryManager.ProductRepository.CartItemPrice(cartItem.OptionId, cartItem.Quantity, cancellationToken);
			detail = new PurchaseDetailEntity();
			detail.PurchaseOptions ??= new List<PurchaseDetailOptions>();
			detail.ProductId = cartItem.ProductId;
			detail.PurchaseOptions.Add(new PurchaseDetailOptions
			{
				OptionId = cartItem.OptionId,
				Quantity = cartItem.Quantity,
				UnitPrice = optionPrice,
			});
			cart.Details.Add(detail);
		}
		else
		{
			PurchaseDetailOptions optionDetail = detail.PurchaseOptions.FirstOrDefault(po => po.OptionId == cartItem.OptionId) ?? throw new Exception("Option not found");
			optionDetail.Quantity += cartItem.Quantity;
			await _repositoryManager.ProductRepository.CheckOptionAviabilityAsync(cartItem.OptionId, optionDetail.Quantity, cancellationToken);
		}
		_repositoryManager.CartRepository.UpdateCartItem(detail);
		await _repositoryManager.UnitOfWork.SaveChangesAsync(userId, cancellationToken);
	}

	public async Task<int> GetCartDetailsCountAsync(string userId, CancellationToken cancellationToken = default)
	{
		int count = await _repositoryManager.CartRepository.GetCartDetailsCountAsync(userId, cancellationToken);
		return count;
	}
}
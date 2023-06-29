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

	public async Task<IEnumerable<ProductsDiscountResponse>> GetDiscountsPreviewAsync(string userId, Guid productId, int optionId, CancellationToken cancellationToken = default)
	{
		ICollection<DiscountEntity> discounts = await _repositoryManager.DiscountRepository.GetValidDiscountsPreview(userId, optionId, cancellationToken);
		IEnumerable<ProductsDiscountResponse> discountPreviews = discounts.Adapt<IEnumerable<ProductsDiscountResponse>>();
		return discountPreviews;
	}

	public async Task<CartResponse> GetByIdAsync(string id, CancellationToken cancellationToken = default)
	{
		CartEntity cart = await _repositoryManager.CartRepository.GetByIdAsync(id, cancellationToken);
		var cartResponse = cart.Adapt<CartResponse>();
		return cartResponse;
	}

	public async Task<CartResponse> AddPackToCartAsync(string userId, Guid? discountId, int optionId, List<PurchaseDetailDto> cartItems,
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
					UnitPrice = cartItem.Quantity * productOption.Price,
					DiscountApplied = discountId != null ? new AppliedDiscountEntity
					{
						DiscountId = (Guid)discountId,
						UserId = userId
					} : null,
				});

				cart.Details.Add(cartItemEntity);
			}
			else
			{
				var purchaseOption = cartItemEntity.PurchaseOptions.FirstOrDefault(po => po.OptionId == cartItem.OptionId);
				if (purchaseOption == null)
					throw new Exception("Option not found");
				purchaseOption.Quantity += cartItem.Quantity;
				if (discountId != null && purchaseOption.AppliedId == null)
					purchaseOption.DiscountApplied = new AppliedDiscountEntity
					{
						DiscountId = (Guid)discountId,
						UserId = userId,
					};
			}
		}
		_repositoryManager.CartRepository.UpdateCart(cart);
		await _repositoryManager.UnitOfWork.SaveChangesAsync(userId, cancellationToken);
		var cartResponse = cart.Adapt<CartResponse>();
		return cartResponse;
	}

	public async Task AdjustCartItemQuantityAsync(string userId, int purchaseNumber, int optionId, int adjust, CancellationToken cancellationToken = default)
	{
		PurchaseDetailOptions optionDetail = await _repositoryManager.PurchaseDetailRepository.GetOptionDetailAsync(optionId, purchaseNumber, cancellationToken);
		OptionEntity option = await _repositoryManager.ProductRepository.GetOptionByIdAsync(optionId, cancellationToken);
		if (option.QuantityAvailable < optionDetail.Quantity + adjust)
			throw new Exception("Not enough quantity available");
		optionDetail.Quantity -= adjust;
		_repositoryManager.CartRepository.UpdateDetailOption(optionDetail);
		await _repositoryManager.UnitOfWork.SaveChangesAsync(userId, cancellationToken);
	}

	public async Task<CartResponse> RemoveCartItemAsync(string userId, Guid productId, int? optionId,
		CancellationToken cancellationToken = default)
	{
		CartEntity cart = await _repositoryManager.CartRepository.GetByIdAsync(userId, cancellationToken);
		if (cart.Details == null) throw new Exception("Cart is empty");
		PurchaseDetailEntity cartItem = cart.Details.FirstOrDefault(cp => cp.ProductId == productId) ?? throw new Exception("Product not found in cart");
		if (optionId != null)
			cartItem.PurchaseOptions.Remove(cartItem.PurchaseOptions.FirstOrDefault(po => po.OptionId == optionId) ?? throw new Exception("Option not found in cart"));
		else
			cart.Details.Remove(cartItem);
		_repositoryManager.CartRepository.UpdateCart(cart);
		await _repositoryManager.UnitOfWork.SaveChangesAsync(userId, cancellationToken);
		var cartResponse = cart.Adapt<CartResponse>();
		return cartResponse;
	}

	public async Task<CartResponse> ClearCartAsync(string userId, CancellationToken cancellationToken = default)
	{
		CartEntity cart = await _repositoryManager.CartRepository.GetByIdAsync(userId, cancellationToken);
		if (cart.Details == null) throw new Exception("Cart is empty");
		cart.Details.Clear();
		_repositoryManager.CartRepository.UpdateCart(cart);
		await _repositoryManager.UnitOfWork.SaveChangesAsync(userId, cancellationToken);
		var cartResponse = cart.Adapt<CartResponse>();
		return cartResponse;
	}

	public async Task<CartResponse> AddProductToCartAsync(string userId, Guid? Code, PurchaseDetailDto cartItem,
		CancellationToken cancellationToken = default)
	{
		CartEntity cart = await _repositoryManager.CartRepository.GetByIdAsync(userId, cancellationToken);
		cart.Details ??= new List<PurchaseDetailEntity>();
		PurchaseDetailEntity? detail = cart.Details.FirstOrDefault(cp => cp.ProductId == cartItem.ProductId);
		var option = await _repositoryManager.ProductRepository.GetOptionByIdAsync(cartItem.OptionId, cancellationToken);
		if (detail == null)
		{
			if (option.QuantityAvailable < cartItem.Quantity)
				throw new Exception($"You are adding {cartItem.Quantity - option.QuantityAvailable} more items than the quantity available");
			detail = new PurchaseDetailEntity();
			detail.ProductId = cartItem.ProductId;
			detail.PurchaseOptions.Add(new PurchaseDetailOptions
			{
				OptionId = cartItem.OptionId,
				Quantity = cartItem.Quantity,
				UnitPrice = cartItem.Quantity * option.Price,
				DiscountApplied = Code != null ? new AppliedDiscountEntity
				{
					DiscountId = (Guid)Code,
					UserId = userId
				} : null,
			});
			cart.Details.Add(detail);
		}
		else
		{
			PurchaseDetailOptions optionDetail = detail.PurchaseOptions.FirstOrDefault(po => po.OptionId == cartItem.OptionId) ?? throw new Exception("Option not found");
			optionDetail.Quantity += cartItem.Quantity;
			if (optionDetail.Quantity < option.QuantityAvailable)
				throw new Exception($"You are adding {optionDetail.Quantity - option.QuantityAvailable} more items than the quantity available");
			if (Code != null && optionDetail.AppliedId == null)
			{
				optionDetail.DiscountApplied = new AppliedDiscountEntity
				{
					DiscountId = (Guid)Code,
					UserId = userId
				};
			}
		}
		_repositoryManager.CartRepository.UpdateCartItem(detail);
		await _repositoryManager.UnitOfWork.SaveChangesAsync(userId, cancellationToken);
		var cartResponse = cart.Adapt<CartResponse>();
		return cartResponse;
	}
}
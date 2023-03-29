using System.Diagnostics;
using Contracts.Model.Product;
using Contracts.Model.Product.Response;
using Contracts.Model.Product.UserInteract;
using Domain.Entities.Product;
using Domain.Entities.Product.Helpers;
using Domain.Entities.Product.UserInteract;
using Domain.Entities.Security;
using Domain.IRepository;
using Mapster;
using Services.Abstractions;

namespace Services;

internal sealed class CartService : ICartService {
    private readonly IRepositoryManager _repositoryManager;

    public CartService(IRepositoryManager repositoryManager) {
        _repositoryManager = repositoryManager;
    }

    public async Task<IEnumerable<CartResponse>> GetAllAsync(CancellationToken cancellationToken = default)
     {
        IEnumerable<CartEntity> cart = await _repositoryManager.CartRepository.GetAllAsync(cancellationToken);
        IEnumerable<CartResponse> cartResponse = cart.Adapt<IEnumerable<CartResponse>>();
        return cartResponse;
     }
    
    public async Task<IEnumerable<ProductsDiscountResponse>> GetDiscountsPreviewAsync(string userId, string productCode,
        int? optionId,
        CancellationToken cancellationToken)
    {
        PurchaseDetailEntity detail = await _repositoryManager.PurchaseDetailRepository.GetDetailByProduct(productCode, optionId, cancellationToken);
        ICollection<ProductsDiscountsEntity> discounts = await _repositoryManager.DiscountRepository.GetDiscountPreviewsAsync(productCode, optionId, cancellationToken);
        foreach (var d in discounts)
        {
            if(d.Discount.AppliedDiscounts != null && d.Discount.AppliedDiscounts.Count(x => x.UserId == userId && x.DiscountCode == d.DiscountCode) * detail.Quantity >= d.Discount.MaxTimesApply)
                discounts.Remove(d);
        }
        IEnumerable<ProductsDiscountResponse> discountPreviews = discounts.Adapt<IEnumerable<ProductsDiscountResponse>>();
        return discountPreviews;
    }

     public async Task<CartResponse> GetByIdAsync(string id, CancellationToken cancellationToken = default)
     {
        CartEntity cart = await _repositoryManager.CartRepository.GetByIdAsync(id, cancellationToken);
        var cartResponse = cart.Adapt<CartResponse>();
        return cartResponse;
     }

     public async Task<CartResponse> AddPackToCartAsync(string userId, List<PurchaseDetailDto> cartItems,
         CancellationToken cancellationToken = default)
     {
         CartEntity cart = await _repositoryManager.CartRepository.GetByIdAsync(userId, cancellationToken);
        cart.Details ??= new List<PurchaseDetailEntity>();
        foreach (var cartItem in cartItems)
        {
            var product = await _repositoryManager.ProductRepository.GetByIdAsync(cartItem.ProductId, cancellationToken);
            if (product.QuantityAvaliable < cartItem.Quantity + cart.Details.Where(cd => cd.ProductId == cartItem.ProductId).Sum(cd => cd.Quantity))
                throw new Exception("Not enough quantity available");
            PurchaseDetailEntity? cartItemEntity = cart.Details.FirstOrDefault(cp => cp.ProductId == cartItem.ProductId);
            if (cartItemEntity == null)
            {
                cartItemEntity = new PurchaseDetailEntity
                {
                    ProductId = cartItem.ProductId,
                    Quantity = cartItem.Quantity,
                    UnitPrice = cartItem.Quantity * product.Price
                };
                cart.Details.Add(cartItemEntity);
            }
            else
            {
                cartItemEntity.Quantity += cartItem.Quantity;
            }
        }
        
        _repositoryManager.CartRepository.UpdateCart(cart);
        await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        var cartResponse = cart.Adapt<CartResponse>();
        return cartResponse;
     }

     public async Task<CartResponse> AdjustCartItemQuantityAsync(string userId, string productId, int adjust,
         CancellationToken cancellationToken = default)
     {
         var product = await _repositoryManager.ProductRepository.GetByIdAsync(productId, cancellationToken);
         if (product.QuantityAvaliable < adjust)
         {
             throw new Exception("Not enough quantity available");
         } 
         CartEntity cart = await _repositoryManager.CartRepository.GetByIdAsync(userId, cancellationToken);
         if (cart.Details == null) throw new Exception("Cart is empty");
         PurchaseDetailEntity? cartItem = cart.Details.FirstOrDefault(cp => cp.ProductId == productId);
         if (cartItem == null) throw new Exception("Product not found in cart");
         cartItem.Quantity -= adjust;
         _repositoryManager.CartRepository.UpdateCartItem(cartItem);
         await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
         var cartResponse = cart.Adapt<CartResponse>();
         return cartResponse;
     }

     public async Task<CartResponse> RemoveCartItemAsync(string userId, string productId, CancellationToken cancellationToken = default)
     {
        CartEntity cart = await _repositoryManager.CartRepository.GetByIdAsync(userId, cancellationToken);
        if (cart.Details == null) throw new Exception("Cart is empty");
        PurchaseDetailEntity cartItem = cart.Details.FirstOrDefault(cp => cp.ProductId == productId) ?? throw new Exception("Product not found in cart");
        cart.Details.Remove(cartItem);
        _repositoryManager.CartRepository.UpdateCart(cart);
        await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        var cartResponse = cart.Adapt<CartResponse>();
        return cartResponse;
     }

     public async Task<CartResponse> ClearCartAsync(string userId, CancellationToken cancellationToken = default)
     {
        CartEntity cart = await _repositoryManager.CartRepository.GetByIdAsync(userId, cancellationToken);
        if (cart.Details == null) throw new Exception("Cart is empty");
        cart.Details.Clear();
        _repositoryManager.CartRepository.UpdateCart(cart);
        await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        var cartResponse = cart.Adapt<CartResponse>();
        return cartResponse;
     }

     public async Task<CartResponse> AddProductToCartAsync(string userId, string? discountCode, PurchaseDetailDto cartItem,
         CancellationToken cancellationToken = default)
     {
         CartEntity cart = await _repositoryManager.CartRepository.GetByIdAsync(userId, cancellationToken);
         ProductEntity product = await _repositoryManager.ProductRepository.GetByIdAsync(cartItem.ProductId, cancellationToken);
         cart.Details ??= new List<PurchaseDetailEntity>();
         PurchaseDetailEntity? detail = cart.Details.FirstOrDefault(cp => cp.ProductId == cartItem.ProductId);
         if(cartItem.OptionId != null)
         {
             if (product.Options == null)
                 throw new Exception("Product has no options");
             var option = product.Options.FirstOrDefault(o => o.Id == cartItem.OptionId) ?? throw new Exception("Option not found");
             product = option.Adapt<ProductEntity>();
         } 
         if (detail == null || detail.OptionId == null)
        {
            if (product.QuantityAvaliable < cartItem.Quantity)
                throw new Exception($"You are adding {cartItem.Quantity - product.QuantityAvaliable} more items than the quantity available");
            detail = new PurchaseDetailEntity
            {
                Quantity = cartItem.Quantity,
                UnitPrice = cartItem.Quantity * product.Price,
                CreatedAt = DateTimeOffset.UtcNow,
                ProductId = cartItem.ProductId,
                OptionId = cartItem.OptionId ?? null
            };
            cart.Details.Add(detail);
        }
        else
        {
            var itemQuantity = cartItem.Quantity + detail.Quantity;
            if (product.QuantityAvaliable < itemQuantity)
                throw new Exception($"You are adding {itemQuantity - product.QuantityAvaliable} more items than the quantity available");
            detail.Quantity += cartItem.Quantity;
        }
        if (discountCode != null && detail.AppliedId == null)
        {
            detail.DiscountApplied = new AppliedDiscountEntity
            {
                DiscountCode = discountCode,
                UserId = userId,
                AppliedDate = DateTimeOffset.UtcNow,
            }; 
        }
        _repositoryManager.CartRepository.UpdateCartItem(detail);
        await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        var cartResponse = cart.Adapt<CartResponse>();
        return cartResponse;
     }
}
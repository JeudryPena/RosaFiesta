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

     public async Task<CartResponse> AddProductToCartAsync(string userId, PurchaseDetailDto cartItem, CancellationToken cancellationToken = default)
     {
         PurchaseDetailEntity cartDetail = cartItem.Adapt<PurchaseDetailEntity>();
         CartEntity cart = await _repositoryManager.CartRepository.GetByIdAsync(userId, cancellationToken);
         ProductEntity product = await _repositoryManager.ProductRepository.GetByIdAsync(cartItem.ProductId, cancellationToken);
         cart.Details ??= new List<PurchaseDetailEntity>();
         var itemQuantity = cartItem.Quantity + cart.Details.Where(cd => cd.ProductId == cartItem.ProductId).Sum(cd => cd.Quantity);
         if (product.QuantityAvaliable < itemQuantity)
             throw new Exception($"You are adding {itemQuantity - product.QuantityAvaliable} more items than the quantity available");
         cartDetail.UnitPrice = product.Price;
         cartDetail.CreatedAt = DateTimeOffset.UtcNow;
         PurchaseDetailEntity? existingCart = cart.Details.FirstOrDefault(cp => cp.ProductId == cartDetail.ProductId);
         if (existingCart == null) 
             cart.Details.Add(cartDetail);
         else 
             existingCart.Quantity += cartDetail.Quantity;
         _repositoryManager.CartRepository.UpdateCart(cart);
         await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
         var cartResponse = cart.Adapt<CartResponse>();
         return cartResponse;
     }
}
using Contracts.Model.Product;
using Contracts.Model.Product.Response;
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
        var cartResponse = cart.Adapt<IEnumerable<CartResponse>>();
        return cartResponse;
     }

     public async Task<CartResponse> GetByIdAsync(string id, CancellationToken cancellationToken = default)
     {
        CartEntity cart = await _repositoryManager.CartRepository.GetByIdAsync(id, cancellationToken);
        var cartResponse = cart.Adapt<CartResponse>();
        return cartResponse;
     }

     public async Task<CartResponse> AddToCartAsync(string userId, List<PurchaseDetailDto> cartItems,
         CancellationToken cancellationToken = default)
     {
         List<double> priceUnit = new();
         foreach (var item in cartItems)
         {
             var product = await _repositoryManager.ProductRepository.GetByIdAsync(item.ProductId, cancellationToken);
             if (product.QuantityAvaliable < item.Quantity)
             {
                 throw new Exception("You can't add more than the quantity available");
             }
            priceUnit.Add(product.Price);
         }
         List<PurchaseDetailEntity> cartDetails = cartItems.Adapt<List<PurchaseDetailEntity>>();
         CartEntity cart = await _repositoryManager.CartRepository.GetByIdAsync(userId, cancellationToken);
         
            if (cart.Details == null)
            {
                cart.Details = cartDetails;
            }
            else
            {
                foreach (var item in cartDetails)
                {
                    PurchaseDetailEntity? cartItem = cart.Details.FirstOrDefault(cp => cp.ProductId == item.ProductId);
                    if (cartItem == null)
                    {
                        cart.Details.Add(item);
                    }
                    else
                    {
                        cartItem.Quantity += item.Quantity;
                    }
                }
            }

            foreach (var item in cart.Details)
            {
                item.CreatedAt = DateTimeOffset.UtcNow;
                item.UnitPrice = priceUnit[cartDetails.IndexOf(item)];
            }
            _repositoryManager.CartRepository.UpdateCart(cart);
         await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
         var cartResponse = cart.Adapt<CartResponse>();
         if (cartResponse.Details != null)
             cartResponse.TotalPrice = cartResponse.Details.Sum(cp => cp.UnitPrice * cp.Quantity);
         return cartResponse;
     }

     public async Task<CartResponse> AdjustCartItemQuantityAsync(string userId, string productId, int decrease,
         CancellationToken cancellationToken = default)
     {
         var product = await _repositoryManager.ProductRepository.GetByIdAsync(productId, cancellationToken);
         if (product.QuantityAvaliable < decrease)
         {
             throw new Exception("Not enough quantity available");
         } 
         CartEntity cart = await _repositoryManager.CartRepository.GetByIdAsync(userId, cancellationToken);
         if (cart.Details == null) throw new Exception("Cart is empty");
         PurchaseDetailEntity? cartItem = cart.Details.FirstOrDefault(cp => cp.ProductId == productId);
         if (cartItem == null) throw new Exception("Product not found in cart");
         cartItem.Quantity -= decrease;
         _repositoryManager.CartRepository.UpdateCartItem(cartItem);
         await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
         var cartResponse = cart.Adapt<CartResponse>();
         return cartResponse;
     }
}
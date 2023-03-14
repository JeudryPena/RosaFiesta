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

     public async Task<CartResponse> AddToCartAsync(string userId, List<CartItemsDto> cartItems,
         CancellationToken cancellationToken = default)
     {
         foreach (var item in cartItems)
         {
             var product = await _repositoryManager.ProductRepository.GetByIdAsync(item.ProductId, cancellationToken);
             if (product.QuantityAvaliable < item.Quantity)
             {
                 throw new Exception("Not enough quantity available");
             } 
             product.QuantityAvaliable -= item.Quantity;
             product.Stock = productStock(product.QuantityAvaliable);
             _repositoryManager.ProductRepository.Update(product);
         }
         CartEntity cart = await _repositoryManager.CartRepository.GetByIdAsync(userId, cancellationToken);
         List<CartProductsEntity> cartProducts = cartItems.Adapt<List<CartProductsEntity>>();
         cartProducts.ForEach(cp => cp.CartId = cart.CartId);
         _repositoryManager.CartRepository.Insert(cartProducts);
         await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
         var cartResponse = cart.Adapt<CartResponse>();
         return cartResponse;
     }
     
     private StockStatusType productStock(int? productQuantityAvaliable)
     {
         if (productQuantityAvaliable <= 0)
             return StockStatusType.OutOfStock;
         if (productQuantityAvaliable <= 5)
             return StockStatusType.LowStock;
         return StockStatusType.InStock;
     }
}
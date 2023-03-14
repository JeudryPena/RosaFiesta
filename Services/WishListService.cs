using Domain.IRepository;
using Services.Abstractions;

namespace Services;

internal sealed class WishListService: IWishListService
{
    private readonly IRepositoryManager _repositoryManager;
    
    public WishListService(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }
}
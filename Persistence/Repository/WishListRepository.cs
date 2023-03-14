using Domain.IRepository;

namespace Persistence.Repository;

internal sealed class WishListRepository: IWishListRepository
{
    private readonly RosaFiestaContext _rosaFiestaContext;
    
    public WishListRepository(RosaFiestaContext rosaFiestaContext)
    {
        _rosaFiestaContext = rosaFiestaContext;
    }
}
using Domain.IRepository;

namespace Persistence.Repository;

internal sealed class PayMethodRepository: IPayMethodRepository
{
    private readonly RosaFiestaContext _context;
    
    public PayMethodRepository(RosaFiestaContext context)
    {
        _context = context;
    }
    
}
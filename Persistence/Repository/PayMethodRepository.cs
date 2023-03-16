using Domain.Entities.Product.UserInteract;
using Domain.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repository;

internal sealed class PayMethodRepository: IPayMethodRepository
{
    private readonly RosaFiestaContext _context;
    
    public PayMethodRepository(RosaFiestaContext context)
    {
        _context = context;
    }
    
    public async Task<PayMethodEntity> GetByIdAsync(Guid payMethodId, CancellationToken cancellationToken)
    {
        PayMethodEntity? payMethod = await _context.PayMethods.FirstOrDefaultAsync(x => x.Id == payMethodId);
        if (payMethod == null) 
            throw new ArgumentNullException(nameof(payMethod));
        return payMethod;
    }
}
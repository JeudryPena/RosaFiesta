using Domain.Entities.Product;
using Domain.Exceptions;
using Domain.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repository;

internal sealed class SupplierRepository: ISupplierRepository
{
    private readonly RosaFiestaContext _dbContext;
    public SupplierRepository(RosaFiestaContext dbContext) => _dbContext = dbContext;
    
    public async Task<IEnumerable<SupplierEntity>> GetAllAsync(CancellationToken cancellationToken = default)
    => await _dbContext.Suppliers.Include(x => x.ProductsSupplied).ToListAsync(cancellationToken);

    public async Task<SupplierEntity> GetByIdAsync(Guid supplierId, CancellationToken cancellationToken = default)
    {
        SupplierEntity? supplier = await _dbContext.Suppliers.Include(x => x.ProductsSupplied)
            .FirstOrDefaultAsync(x => x.Id == supplierId, cancellationToken);
        if (supplier == null)
            throw new ArgumentNullException(nameof(supplier));
        return supplier;
    }

    public void Insert(SupplierEntity supplier) => _dbContext.Suppliers.Add(supplier);
    public void Update(SupplierEntity supplier) => _dbContext.Suppliers.Update(supplier);
    public void Delete(SupplierEntity supplier) => _dbContext.Suppliers.Remove(supplier);
}
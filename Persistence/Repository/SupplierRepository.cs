using Domain.Entities.Product;
using Domain.IRepository;

using Microsoft.EntityFrameworkCore;

namespace Persistence.Repository;

internal sealed class SupplierRepository : ISupplierRepository
{
	private readonly RosaFiestaContext _dbContext;
	public SupplierRepository(RosaFiestaContext dbContext) => _dbContext = dbContext;

	public async Task<IEnumerable<SupplierEntity>> GetSuppliersAsync(CancellationToken cancellationToken = default) => await _dbContext.Suppliers.ToListAsync(cancellationToken);

	public void Delete(SupplierEntity supplier)
	=> _dbContext.Suppliers.Remove(supplier);

	public async Task<IEnumerable<SupplierEntity>> GetAllAsync(CancellationToken cancellationToken = default)
	=> await _dbContext.Suppliers.Include(x => x.Products).ThenInclude(x => x.Option).ToListAsync(cancellationToken);

	public async Task<SupplierEntity> GetByIdAsync(Guid supplierId, CancellationToken cancellationToken = default)
	{
		SupplierEntity? supplier = await _dbContext.Suppliers.Include(x => x.Products).ThenInclude(x => x.Option)
			.FirstOrDefaultAsync(x => x.Id == supplierId, cancellationToken);
		if (supplier == null)
			throw new ArgumentNullException(nameof(supplier));
		return supplier;
	}

	public void Insert(SupplierEntity supplier) => _dbContext.Suppliers.Add(supplier);
	public void Update(SupplierEntity supplier) => _dbContext.Suppliers.Update(supplier);
	public async Task VerifyUniqueEmail(string? supplierEmail, CancellationToken cancellationToken)
	{
		bool supplierExists = await _dbContext.Suppliers.AnyAsync(x => x.Email == supplierEmail, cancellationToken);
		if (supplierExists)
			throw new Exception("Ya existe un proveedor con ese correo electrónico");
	}

	public async Task VerifyUniquePhone(string? supplierPhone, CancellationToken cancellationToken)
	{
		bool supplierExists = await _dbContext.Suppliers.AnyAsync(x => x.Phone == supplierPhone, cancellationToken);
		if (supplierExists)
			throw new Exception("Ya existe un proveedor con ese número de teléfono");
	}

	public async Task VerifyUniqueEmailUpdate(Guid supplierId, string? supplierEmail, CancellationToken cancellationToken)
	{
		bool supplierExists = await _dbContext.Suppliers.AnyAsync(x => x.Email == supplierEmail && x.Id != supplierId, cancellationToken);
		if (supplierExists)
			throw new Exception("Ya existe un proveedor con ese correo electrónico");
	}

	public async Task VerifyUniquePhoneUpdate(Guid supplierId, string? supplierPhone, CancellationToken cancellationToken)
	{
		bool supplierExists = await _dbContext.Suppliers.AnyAsync(x => x.Phone == supplierPhone && x.Id != supplierId, cancellationToken);
		if (supplierExists)
			throw new Exception("Ya existe un proveedor con ese número de teléfono");
	}
}
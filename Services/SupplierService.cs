using Contracts.Model.Product;
using Contracts.Model.Product.Response;

using Domain.Entities.Product;
using Domain.IRepository;

using Mapster;

using Services.Abstractions;

namespace Services;

internal sealed class SupplierService : ISupplierService
{
	private readonly IRepositoryManager _repositoryManager;

	public SupplierService(IRepositoryManager repositoryManager)
	{
		_repositoryManager = repositoryManager;
	}

	public async Task<IEnumerable<SuppliersListResponse>> GetSuppliersAsync(CancellationToken cancellationToken = default)
	{
		IEnumerable<SupplierEntity> suppliers = await _repositoryManager.SupplierRepository.GetSuppliersAsync(cancellationToken);
		var supplierResponse = suppliers.Adapt<IEnumerable<SuppliersListResponse>>();
		return supplierResponse;
	}

	public async Task<IEnumerable<SupplierResponse>> GetAllAsync(CancellationToken cancellationToken = default)
	{
		IEnumerable<SupplierEntity> suppliers = await _repositoryManager.SupplierRepository.GetAllAsync(cancellationToken);
		foreach (var supplier in suppliers)
		{
			supplier.CreatedBy = await _repositoryManager.UserRepository.GetUserName(supplier.CreatedBy, cancellationToken);
			if (supplier.UpdatedBy != null)
				supplier.UpdatedBy = await _repositoryManager.UserRepository.GetUserName(supplier.UpdatedBy, cancellationToken);
		}
		var supplierResponse = suppliers.Adapt<IEnumerable<SupplierResponse>>();
		return supplierResponse;
	}

	public async Task<SupplierResponse> GetByIdAsync(Guid supplierId, CancellationToken cancellationToken = default)
	{
		SupplierEntity supplier = await _repositoryManager.SupplierRepository.GetByIdAsync(supplierId, cancellationToken);
		var supplierResponse = supplier.Adapt<SupplierResponse>();
		supplierResponse.CreatedBy = await _repositoryManager.UserRepository.GetUserName(supplier.CreatedBy, cancellationToken);
		if (supplier.UpdatedBy != null)
			supplierResponse.UpdatedBy = await _repositoryManager.UserRepository.GetUserName(supplier.UpdatedBy, cancellationToken);
		return supplierResponse;
	}

	public async Task CreateAsync(string userId, SupplierDto supplierDto, CancellationToken cancellationToken = default)
	{
		var supplier = supplierDto.Adapt<SupplierEntity>();
		await _repositoryManager.SupplierRepository.VerifyUniqueEmail(supplier.Email, cancellationToken);
		await _repositoryManager.SupplierRepository.VerifyUniquePhone(supplier.Phone, cancellationToken);
		_repositoryManager.SupplierRepository.Insert(supplier);
		if (supplierDto.SupplierProducts != null)
			foreach (var product in supplierDto.SupplierProducts)
			{
				var productToAdd = await _repositoryManager.ProductRepository.GetByIdAsync(product.Id, cancellationToken);
				productToAdd.SupplierId = supplier.Id;
				_repositoryManager.ProductRepository.Update(productToAdd);
			}
		await _repositoryManager.UnitOfWork.SaveChangesAsync(userId, cancellationToken);
	}

	public async Task UpdateAsync(string userId, Guid supplierId, SupplierDto supplierDto,
		CancellationToken cancellationToken = default)
	{
		SupplierEntity supplier = await _repositoryManager.SupplierRepository.GetByIdAsync(supplierId, cancellationToken);
		supplier = supplierDto.Adapt(supplier);
		await _repositoryManager.SupplierRepository.VerifyUniqueEmailUpdate(supplier.Id, supplier.Email, cancellationToken);
		await _repositoryManager.SupplierRepository.VerifyUniquePhoneUpdate(supplier.Id, supplier.Phone, cancellationToken);
		_repositoryManager.SupplierRepository.Update(supplier);
		if (supplierDto.SupplierProducts != null)
		{
			supplier.Products = null;
			foreach (var product in supplierDto.SupplierProducts)
			{

				var productToAdd = await _repositoryManager.ProductRepository.GetByIdAsync(product.Id, cancellationToken);
				productToAdd.SupplierId = supplier.Id;
				_repositoryManager.ProductRepository.Update(productToAdd);
			}
		}
		await _repositoryManager.UnitOfWork.SaveChangesAsync(userId, cancellationToken);
	}

	public async Task DeleteAsync(string userId, Guid supplierId, CancellationToken cancellationToken = default)
	{
		SupplierEntity supplier = await _repositoryManager.SupplierRepository.GetByIdAsync(supplierId, cancellationToken);
		_repositoryManager.SupplierRepository.Delete(supplier);
		await _repositoryManager.UnitOfWork.SaveChangesAsync(userId, cancellationToken);
	}

	public async Task DeleteProductFromSupplierAsync(string userId, Guid supplierId, Guid productId, CancellationToken cancellationToken = default)
	{
		SupplierEntity supplier = await _repositoryManager.SupplierRepository.GetByIdAsync(supplierId, cancellationToken);
		if (supplier.Products == null)
			throw new Exception("Warranty does not have any products");
		var product = supplier.Products.FirstOrDefault(x => x.Id == productId);
		if (product == null)
			throw new Exception("Product does not exist in this supplier");
		supplier.Products.Remove(product);
		_repositoryManager.SupplierRepository.Update(supplier);
		await _repositoryManager.UnitOfWork.SaveChangesAsync(userId, cancellationToken);
	}
}
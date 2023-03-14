using Contracts.Model.Product;
using Contracts.Model.Product.Response;
using Domain.Entities.Product;
using Domain.IRepository;
using Mapster;
using Services.Abstractions;

namespace Services;

internal sealed class SupplierService: ISupplierService
{
    private readonly IRepositoryManager _repositoryManager;

    public SupplierService(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }
    
    public async Task<IEnumerable<SupplierResponse>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        IEnumerable<SupplierEntity> suppliers = await _repositoryManager.SupplierRepository.GetAllAsync(cancellationToken);
        var supplierResponse = suppliers.Adapt<IEnumerable<SupplierResponse>>();
        return supplierResponse;
    }

    public async Task<SupplierResponse> GetByIdAsync(Guid supplierId, CancellationToken cancellationToken = default)
    {
        SupplierEntity supplier = await _repositoryManager.SupplierRepository.GetByIdAsync(supplierId, cancellationToken);
        var supplierResponse = supplier.Adapt<SupplierResponse>();
        return supplierResponse;
    }

    public async Task<SupplierResponse> CreateAsync(string? username, SupplierDto supplierDto, CancellationToken cancellationToken = default)
    {
        var supplier = supplierDto.Adapt<SupplierEntity>();
        supplier.CreatedBy = username;
        supplier.CreatedAt = DateTimeOffset.UtcNow;
        supplier.Id = Guid.NewGuid();
        supplier.IsActive = true;

        _repositoryManager.SupplierRepository.Insert(supplier);
        await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        var supplierResponse = supplier.Adapt<SupplierResponse>();
        return supplierResponse;
    }

    public async Task<SupplierResponse> UpdateAsync(string? username, Guid supplierId, SupplierDto supplierDto,
        CancellationToken cancellationToken = default)
    {
        SupplierEntity supplier = await _repositoryManager.SupplierRepository.GetByIdAsync(supplierId, cancellationToken);
        supplier.Name = supplierDto.Name;
        supplier.Description = supplierDto.Description;
        supplier.IsActive = supplierDto.IsActive;
        supplier.Address = supplierDto.Address;
        supplier.Phone = supplierDto.Phone;
        supplier.Email = supplierDto.Email;
        supplier.UpdatedBy = username;
        supplier.UpdatedAt = DateTimeOffset.UtcNow;
        _repositoryManager.SupplierRepository.Update(supplier);
        await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        var supplierResponse = supplier.Adapt<SupplierResponse>();
        return supplierResponse;    
    }

    public async Task DeleteAsync(Guid supplierId, CancellationToken cancellationToken = default)
    {
        SupplierEntity supplier = await _repositoryManager.SupplierRepository.GetByIdAsync(supplierId, cancellationToken);
        _repositoryManager.SupplierRepository.Delete(supplier);
        await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
    }
}
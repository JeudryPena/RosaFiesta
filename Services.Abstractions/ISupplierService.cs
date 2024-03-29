﻿using Contracts.Model.Product;
using Contracts.Model.Product.Response;

namespace Services.Abstractions;

public interface ISupplierService
{
	Task<IEnumerable<SupplierResponse>> GetAllAsync(CancellationToken cancellationToken = default);
	Task<SupplierResponse> GetByIdAsync(Guid supplierId, CancellationToken cancellationToken = default);
	Task CreateAsync(string userId, SupplierDto supplierDto, CancellationToken cancellationToken = default);
	Task UpdateAsync(string userId, Guid supplierId, SupplierDto supplierDto, CancellationToken cancellationToken = default);
	Task DeleteAsync(string userId, Guid supplierId, CancellationToken cancellationToken = default);
	Task<IEnumerable<SuppliersListResponse>> GetSuppliersAsync(CancellationToken cancellationToken = default);
	Task DeleteProductFromSupplierAsync(string userId, Guid supplierId, Guid productId, CancellationToken cancellationToken = default);
}
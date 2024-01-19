using Contracts.Model.Product;
using Contracts.Model.Product.Response;

using Domain.Entities.Product;
using Domain.Entities.Product.Helpers;
using Domain.IRepository;

using Mapster;

using Services.Abstractions;

namespace Services;

internal sealed class WarrantyService : IWarrantyService
{
	private readonly IRepositoryManager _repositoryManager;

	public WarrantyService(IRepositoryManager repositoryManager)
	{
		_repositoryManager = repositoryManager;
	}

	public async Task<IEnumerable<WarrantiesListResponse>> GetAllForAdminAsync(CancellationToken cancellationToken = default)
	{
		IEnumerable<WarrantyEntity> warranties = await _repositoryManager.WarrantyRepository.GetWarrantiesList(cancellationToken);

		var warrantyResponse = warranties.Adapt<IEnumerable<WarrantiesListResponse>>();
		return warrantyResponse;
	}

	public async Task<WarrantyPreviewResponse> GetWarrantyPreviewAsync(Guid warrantyId, CancellationToken cancellationToken)
	{
		WarrantyEntity warranty = await _repositoryManager.WarrantyRepository.GetPreviewAsync(warrantyId, cancellationToken);
		WarrantyPreviewResponse warrantyResponse = warranty.Adapt<WarrantyPreviewResponse>();
		return warrantyResponse;
	}

	public async Task<Guid?> GetWarrantyPreviewByProductIdAsync(Guid warrantyId, CancellationToken cancellationToken)
	{
		Guid? id = await _repositoryManager.WarrantyRepository.GetPreviewByProductIdAsync(warrantyId, cancellationToken);
		return id;
	}

	public async Task<IEnumerable<WarrantiesManagementResponse>> GetAllForManagementAsync(CancellationToken cancellationToken = default)
	{
		IEnumerable<WarrantyEntity> warranties = await _repositoryManager.WarrantyRepository.GetAllManagementAsync(cancellationToken);
		foreach (var warranty in warranties)
		{
			warranty.CreatedBy = await _repositoryManager.UserRepository.GetUserName(warranty.CreatedBy, cancellationToken);
			if (warranty.UpdatedBy != null)
				warranty.UpdatedBy = await _repositoryManager.UserRepository.GetUserName(warranty.UpdatedBy, cancellationToken);
		}
		var warrantyResponse = warranties.Adapt<IEnumerable<WarrantiesManagementResponse>>();
		return warrantyResponse;
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	public async Task<IEnumerable<WarrantyPreviewResponse>> GetAllAsync(CancellationToken cancellationToken = default)
	{
		IEnumerable<WarrantyEntity> warranty = await _repositoryManager.WarrantyRepository.GetAllAsync(cancellationToken);
		var warrantyResponse = warranty.Adapt<IEnumerable<WarrantyPreviewResponse>>();
		return warrantyResponse;
	}

	public async Task<WarrantyResponse> GetWarrantyAsync(Guid warrantyId, CancellationToken cancellationToken = default)
	{
		WarrantyEntity warranty = await _repositoryManager.WarrantyRepository.GetByIdAsync(warrantyId, cancellationToken);
		var warrantyResponse = warranty.Adapt<WarrantyResponse>();
		warrantyResponse.CreatedBy = await _repositoryManager.UserRepository.GetUserName(warranty.CreatedBy, cancellationToken);
		if (warranty.UpdatedBy != null)
			warrantyResponse.UpdatedBy = await _repositoryManager.UserRepository.GetUserName(warranty.UpdatedBy, cancellationToken);
		return warrantyResponse;
	}

	public async Task CreateWarrantyAsync(string userId, WarrantyDto warranty, CancellationToken cancellationToken = default)
	{
		var warrantyEntity = warranty.Adapt<WarrantyEntity>();
		_repositoryManager.WarrantyRepository.Insert(warrantyEntity);
		if (warranty.WarrantyProducts != null)
			foreach (var product in warranty.WarrantyProducts)
			{
				var productToAdd = await _repositoryManager.ProductRepository.GetByIdAsync(product.Id, cancellationToken);
				productToAdd.WarrantyId = warrantyEntity.Id;
				_repositoryManager.ProductRepository.Update(productToAdd);
			}

		await _repositoryManager.UnitOfWork.SaveChangesAsync(userId, cancellationToken);
	}

	public async Task UpdateWarrantyAsync(string userId, Guid warrantyId, WarrantyDto warrantyDto, CancellationToken cancellationToken = default)
	{
		WarrantyEntity warranty = await _repositoryManager.WarrantyRepository.GetByIdAsync(warrantyId, cancellationToken);
		warranty = warrantyDto.Adapt(warranty);
		if (warrantyDto.WarrantyProducts != null)
		{
			warranty.Products = null;
			foreach (var product in warrantyDto.WarrantyProducts)
			{

				var productToAdd = await _repositoryManager.ProductRepository.GetByIdAsync(product.Id, cancellationToken);
				productToAdd.WarrantyId = warranty.Id;
				_repositoryManager.ProductRepository.Update(productToAdd);
			}
		}
		_repositoryManager.WarrantyRepository.Update(warranty);
		await _repositoryManager.UnitOfWork.SaveChangesAsync(userId, cancellationToken);
	}

	public async Task DeleteWarrantyAsync(string userId, Guid warrantyId, CancellationToken cancellationToken = default)
	{
		WarrantyEntity warranty = await _repositoryManager.WarrantyRepository.GetByIdAsync(warrantyId, cancellationToken);
		_repositoryManager.WarrantyRepository.Delete(warranty);
		await _repositoryManager.UnitOfWork.SaveChangesAsync(userId, cancellationToken);
	}

	public async Task UpdateWarrantyStatusAsync(string userId, Guid warrantyId, int warrantyStatus, CancellationToken cancellationToken = default)
	{
		WarrantyEntity warranty = await _repositoryManager.WarrantyRepository.GetByIdAsync(warrantyId, cancellationToken);
		warranty.Status = (WarrantyStatusType)warrantyStatus;
		_repositoryManager.WarrantyRepository.Update(warranty);
		await _repositoryManager.UnitOfWork.SaveChangesAsync(userId, cancellationToken);
	}

	public async Task DeleteWarrantyProductAsync(string userId, Guid warrantyId, Guid productId, CancellationToken cancellationToken = default)
	{
		WarrantyEntity warranty = await _repositoryManager.WarrantyRepository.GetByIdAsync(warrantyId, cancellationToken);
		if (warranty.Products == null)
			throw new Exception("Warranty does not have any products");
		warranty.Products.Remove(warranty.Products.FirstOrDefault(x => x.Id == productId));
		_repositoryManager.WarrantyRepository.Update(warranty);
		await _repositoryManager.UnitOfWork.SaveChangesAsync(userId, cancellationToken);
	}
}
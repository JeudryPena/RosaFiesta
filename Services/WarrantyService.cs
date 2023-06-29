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

	public async Task<IEnumerable<WarrantyResponse>> GetAllForManagementAsync(CancellationToken cancellationToken = default)
	{
		IEnumerable<WarrantyEntity> warranty = await _repositoryManager.WarrantyRepository.GetAllAsync(cancellationToken);
		var warrantyResponse = warranty.Adapt<IEnumerable<WarrantyResponse>>();
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
		return warrantyResponse;
	}

	public async Task<WarrantyResponse> CreateWarrantyAsync(string userId, WarrantyDto warranty, CancellationToken cancellationToken = default)
	{
		var warrantyEntity = warranty.Adapt<WarrantyEntity>();
		warrantyEntity.Status = WarrantyStatusType.Active;
		_repositoryManager.WarrantyRepository.Insert(warrantyEntity);
		await _repositoryManager.UnitOfWork.SaveChangesAsync(userId, cancellationToken);
		var warrantyResponse = warrantyEntity.Adapt<WarrantyResponse>();
		return warrantyResponse;
	}

	public async Task<WarrantyResponse> UpdateWarrantyAsync(string userId, Guid warrantyId, WarrantyDto warrantyDto, CancellationToken cancellationToken = default)
	{
		WarrantyEntity warranty = await _repositoryManager.WarrantyRepository.GetByIdAsync(warrantyId, cancellationToken);
		warranty.Name = warrantyDto.Name;
		warranty.Description = warrantyDto.Description;
		warranty.Period = warrantyDto.Period;
		warranty.Conditions = warrantyDto.Conditions;
		warranty.Type = warrantyDto.Type.Adapt<WarrantyType>();
		_repositoryManager.WarrantyRepository.Update(warranty);
		await _repositoryManager.UnitOfWork.SaveChangesAsync(userId, cancellationToken);
		var warrantyResponse = warranty.Adapt<WarrantyResponse>();
		return warrantyResponse;
	}

	public async Task DeleteWarrantyAsync(string userId, Guid warrantyId, CancellationToken cancellationToken = default)
	{
		WarrantyEntity warranty = await _repositoryManager.WarrantyRepository.GetByIdAsync(warrantyId, cancellationToken);
		_repositoryManager.WarrantyRepository.Delete(warranty);
		await _repositoryManager.UnitOfWork.SaveChangesAsync(userId, cancellationToken);
	}

	public async Task<WarrantyResponse> UpdateWarrantyStatusAsync(string userId, Guid warrantyId, int warrantyStatus, CancellationToken cancellationToken = default)
	{
		WarrantyEntity warranty = await _repositoryManager.WarrantyRepository.GetByIdAsync(warrantyId, cancellationToken);
		warranty.Status = (WarrantyStatusType)warrantyStatus;
		_repositoryManager.WarrantyRepository.Update(warranty);
		await _repositoryManager.UnitOfWork.SaveChangesAsync(userId, cancellationToken);
		var warrantyResponse = warranty.Adapt<WarrantyResponse>();
		return warrantyResponse;
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
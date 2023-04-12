using Contracts.Model.Product;
using Contracts.Model.Product.Response;
using Domain.Entities.Product;
using Domain.Entities.Product.Helpers;
using Domain.Entities.Security;
using Domain.Entities.Security.Helper;
using Domain.IRepository;
using Mapster;
using Services.Abstractions;

namespace Services;

internal sealed class WarrantyService: IWarrantyService
{
    private readonly IRepositoryManager _repositoryManager;
    
    public WarrantyService(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<IEnumerable<WarrantyResponse>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        IEnumerable<WarrantyEntity> warranty = await _repositoryManager.WarrantyRepository.GetAllAsync(cancellationToken);
        var warrantyResponse = warranty.Adapt<IEnumerable<WarrantyResponse>>();
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
        warrantyEntity.CreatedBy = userId;
        warrantyEntity.CreatedAt = DateTimeOffset.UtcNow;
        warrantyEntity.Id = Guid.NewGuid();
        warrantyEntity.Status = WarrantyStatusType.Active;
        _repositoryManager.WarrantyRepository.Insert(warrantyEntity);
        ActionLogEntity actionLog = new()
        {
            UserId = userId,
            ActivityType = Activities.Warranty,
            Action = ActivityAction.Created,
        };
        _repositoryManager.ActionLogRepository.Create(actionLog);
        await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
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
        warranty.ScopeType = warrantyDto.ScopeType.Adapt<WarrantyScopeType>();
        warranty.UpdatedBy = userId;
        warranty.UpdatedAt = DateTimeOffset.UtcNow;
        _repositoryManager.WarrantyRepository.Update(warranty);
        ActionLogEntity actionLog = new()
        {
            UserId = userId,
            ActivityType = Activities.Warranty,
            Action = ActivityAction.Updated,
        };
        _repositoryManager.ActionLogRepository.Create(actionLog);
        await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        var warrantyResponse = warranty.Adapt<WarrantyResponse>();
        return warrantyResponse;
    }

    public async Task DeleteWarrantyAsync(string userId, Guid warrantyId, CancellationToken cancellationToken = default)
    {
        WarrantyEntity warranty = await _repositoryManager.WarrantyRepository.GetByIdAsync(warrantyId, cancellationToken);
        _repositoryManager.WarrantyRepository.Delete(warranty);
        ActionLogEntity actionLog = new()
        {
            UserId = userId,
            ActivityType = Activities.Warranty,
            Action = ActivityAction.Deleted,
        };
        _repositoryManager.ActionLogRepository.Create(actionLog);
        await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task<WarrantyResponse> UpdateWarrantyStatusAsync(string userId, Guid warrantyId, int warrantyStatus, CancellationToken cancellationToken = default)
    {
        WarrantyEntity warranty = await _repositoryManager.WarrantyRepository.GetByIdAsync(warrantyId, cancellationToken);
        warranty.Status = (WarrantyStatusType) warrantyStatus;
        warranty.UpdatedBy = userId;
        warranty.UpdatedAt = DateTimeOffset.UtcNow;
        _repositoryManager.WarrantyRepository.Update(warranty);
        ActionLogEntity actionLog = new()
        {
            UserId = userId,
            ActivityType = Activities.Warranty,
            Action = ActivityAction.Updated,
        };
        _repositoryManager.ActionLogRepository.Create(actionLog);
        await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        var warrantyResponse = warranty.Adapt<WarrantyResponse>();
        return warrantyResponse;
    }
    
}
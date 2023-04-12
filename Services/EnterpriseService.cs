using Contracts.Model.Enterprise;
using Contracts.Model.Enterprise.Response;
using Domain.Entities.Enterprise;
using Domain.Entities.Security;
using Domain.Entities.Security.Helper;
using Domain.IRepository;
using Mapster;
using Services.Abstractions;

namespace Services;

internal sealed class EnterpriseService: IEnterpriseService
{
    private readonly IRepositoryManager _repositoryManager;
    
    public EnterpriseService(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }

    public async Task<IEnumerable<DepartmentPreviewResponse>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        IEnumerable<DepartmentEntity> departmentEntity = await _repositoryManager.EnterpriseRepository.GetDepartmentsAsync(cancellationToken);
        IEnumerable<DepartmentPreviewResponse> departmentPreviewResponses = departmentEntity.Adapt<IEnumerable<DepartmentPreviewResponse>>();
        return departmentPreviewResponses;
    }

    public async Task<IEnumerable<EmployePreviewResponse>> GetAllEmployeesPreview(CancellationToken cancellationToken = default)
    {
        IEnumerable<EmployeeEntity> employeeEntities = await _repositoryManager.EnterpriseRepository.GetEmployeesAsync(cancellationToken);
        IEnumerable<EmployePreviewResponse> employePreviewResponses = employeeEntities.Adapt<IEnumerable<EmployePreviewResponse>>();
        return employePreviewResponses;
    }

    public async Task<DepartmentResponse> GetDepartmentAsync(int departmentId, CancellationToken cancellationToken = default)
    {
        DepartmentEntity departmentEntity = await _repositoryManager.EnterpriseRepository.GetDepartmentAsync(departmentId, cancellationToken);
        DepartmentResponse departmentResponse = departmentEntity.Adapt<DepartmentResponse>();
        return departmentResponse;
    }

    public async Task<EmployeeResponse> GetEmployeeAsync(Guid employeeId, CancellationToken cancellationToken = default)
    {
        EmployeeEntity employeeEntity = await _repositoryManager.EnterpriseRepository.GetEmployeeAsync(employeeId, cancellationToken);
        EmployeeResponse employeeResponse = employeeEntity.Adapt<EmployeeResponse>();
        return employeeResponse;
    }

    public async Task<DepartmentResponse> CreateAsync(string userId, DepartmentDto departmentDto, CancellationToken cancellationToken = default)
    {
        DepartmentEntity departmentEntity = departmentDto.Adapt<DepartmentEntity>(); departmentEntity.CreatedBy = userId;
        _repositoryManager.EnterpriseRepository.CreateDepartment(departmentEntity);
        ActionLogEntity actionLog = new()
        {
            UserId = userId,
            ActivityType = Activities.Department,
            Action = ActivityAction.Created,
        };
        _repositoryManager.ActionLogRepository.Create(actionLog);
        await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        DepartmentResponse departmentResponse = departmentEntity.Adapt<DepartmentResponse>();
        return departmentResponse;
    }

    public async Task<EmployeeResponse> CreateEmployeeAsync(string userId, EmployeeDto employeeDto, CancellationToken cancellationToken = default)
    {
        EmployeeEntity employeeEntity = employeeDto.Adapt<EmployeeEntity>();
        employeeEntity.CreatedBy = userId;
        _repositoryManager.EnterpriseRepository.CreateEmployee(employeeEntity);
        ActionLogEntity actionLog = new()
        {
            UserId = userId,
            ActivityType = Activities.Employee,
            Action = ActivityAction.Created,
        };
        _repositoryManager.ActionLogRepository.Create(actionLog);
        await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        EmployeeResponse employeeResponse = employeeEntity.Adapt<EmployeeResponse>();
        return employeeResponse;
    }

    public async Task<DepartmentResponse> UpdateAsync(string userId, int departmentId, DepartmentDto departmentDto, CancellationToken cancellationToken = default)
    {
        DepartmentEntity departmentEntity = await _repositoryManager.EnterpriseRepository.GetDepartmentAsync(departmentId, cancellationToken);
        departmentEntity = departmentDto.Adapt(departmentEntity);
        departmentEntity.UpdatedAt = DateTimeOffset.Now;
        departmentEntity.UpdatedBy = userId;
        _repositoryManager.EnterpriseRepository.UpdateDepartment(departmentEntity);
        ActionLogEntity actionLog = new()
        {
            UserId = userId,
            ActivityType = Activities.Department,
            Action = ActivityAction.Updated,
        };
        _repositoryManager.ActionLogRepository.Create(actionLog);
        await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        DepartmentResponse departmentResponse = departmentEntity.Adapt<DepartmentResponse>();
        return departmentResponse;
    }

    public async Task<EmployeeResponse> UpdateEmployeeAsync(string userId, Guid employeeId, EmployeeDto employeeDto, CancellationToken cancellationToken = default)
    {
        EmployeeEntity employeeEntity = await _repositoryManager.EnterpriseRepository.GetEmployeeAsync(employeeId, cancellationToken);
        employeeEntity = employeeDto.Adapt(employeeEntity);
        employeeEntity.UpdatedAt = DateTimeOffset.Now;
        employeeEntity.UpdatedBy = userId;
        _repositoryManager.EnterpriseRepository.UpdateEmployee(employeeEntity);
        ActionLogEntity actionLog = new()
        {
            UserId = userId,
            ActivityType = Activities.Employee,
            Action = ActivityAction.Updated,
        };
        _repositoryManager.ActionLogRepository.Create(actionLog);
        await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        EmployeeResponse employeeResponse = employeeEntity.Adapt<EmployeeResponse>();
        return employeeResponse;
    }

    public async Task DeleteAsync(string userId, int departmentId, CancellationToken cancellationToken = default)
    {
        DepartmentEntity departmentAsync = await _repositoryManager.EnterpriseRepository.GetDepartmentAsync(departmentId, cancellationToken);
        _repositoryManager.EnterpriseRepository.DeleteDepartment(departmentAsync);
        ActionLogEntity actionLog = new()
        {
            UserId = userId,
            ActivityType = Activities.Department,
            Action = ActivityAction.Deleted,
        };
        _repositoryManager.ActionLogRepository.Create(actionLog);
        await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteEmployeeAsync(string userId, Guid employeeId, CancellationToken cancellationToken = default)
    {
        EmployeeEntity employeeEntity = await _repositoryManager.EnterpriseRepository.GetEmployeeAsync(employeeId, cancellationToken);
        _repositoryManager.EnterpriseRepository.DeleteEmployee(employeeEntity);
        ActionLogEntity actionLog = new()
        {
            UserId = userId,
            ActivityType = Activities.Employee,
            Action = ActivityAction.Deleted,
        };
        _repositoryManager.ActionLogRepository.Create(actionLog);
        await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
    }
}
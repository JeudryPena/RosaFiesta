using Contracts.Model;
using Contracts.Model.Security;
using Contracts.Model.Security.Response;
using Domain.Entities;
using Domain.Entities.Security;
using Domain.Exceptions;
using Domain.IRepository;
using Mapster;
using Messaging;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Org.BouncyCastle.Asn1.Ocsp;
using Services.Abstractions;

namespace Services;

public class UserService : IUserService
{
    private readonly IRepositoryManager _repositoryManager;

    public UserService(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }

    public async Task<IEnumerable<UsersResponse>> GetAllUserAsync(
        CancellationToken cancellationToken = default
    )
    {
        IEnumerable<UserEntity> users = await _repositoryManager.UserRepository.GetAllAsync(
            cancellationToken
        );
        var usersDto = users.Adapt<IEnumerable<UsersResponse>>();
        return usersDto;
    }

    public async Task<UsersResponse> GetUserByIdAsync(
        Guid userId,
        CancellationToken cancellationToken = default
    )
    {
        UserEntity user = await _repositoryManager.UserRepository.GetByIdAsync(
            userId,
            cancellationToken
        ) ?? throw new UserNotFoundException(userId.ToString());
        UsersResponse usersResponse = user.Adapt<UsersResponse>();
        return usersResponse;
    }
    
    public async Task UpdateAsync(Guid userId, UserForUpdateDto userForUpdateDto, CancellationToken cancellationToken = default)
    {
        UserEntity user = await _repositoryManager.UserRepository.GetByIdAsync(
            userId,
            cancellationToken
        ) ?? throw new UserNotFoundException(userId.ToString());
        
        user.FullName = userForUpdateDto.Name + " " + userForUpdateDto.LastName;
        user.CivilStatus = userForUpdateDto.CivilStatus.Adapt<CivilType>();
        user.BirthDate = userForUpdateDto.BirthDate;
        user.Address = userForUpdateDto.Address;
        user.City = userForUpdateDto.City;
        user.State = userForUpdateDto.State;
        user.UpdatedAt = DateTimeOffset.UtcNow;
        
        await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        UserEntity user = await _repositoryManager.UserRepository.GetByIdAsync(
            userId,
            cancellationToken
        ) ?? throw new UserNotFoundException(userId.ToString());
        
        _repositoryManager.UserRepository.Delete(user);
        await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
    }
}

using Contracts.Model;
using Contracts.Response;
using Domain.Entities;
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

    public async Task<IEnumerable<UserDto>> GetAllUserAsync(
        CancellationToken cancellationToken = default
    )
    {
        IEnumerable<UserEntity> users = await _repositoryManager.UserRepository.GetAllAsync(
            cancellationToken
        );
        var usersDto = users.Adapt<IEnumerable<UserDto>>();
        return usersDto;
    }

    public async Task<UserDto> GetUserByIdAsync(
        Guid userId,
        CancellationToken cancellationToken = default
    )
    {
        UserEntity user = await _repositoryManager.UserRepository.GetByIdAsync(
            userId,
            cancellationToken
        ) ?? throw new UserNotFoundException(userId.ToString());
        UserDto userDto = user.Adapt<UserDto>();
        return userDto;
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
        user.UpdatedAt = DateTime.Now;
        
        await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
    }
    
    
}

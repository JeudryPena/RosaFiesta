using Contracts.Model;
using Contracts.Response;
using Domain.Entities;
using Domain.IRepository;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Services.Abstractions;

namespace Services;

public class UserService : IUserService
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly UserManager<UserEntity> _userManager;

    public UserService(IRepositoryManager repositoryManager, UserManager<UserEntity> userManager)
    {
        _repositoryManager = repositoryManager;
        _userManager = userManager;
    }

    public async Task<RegisterResponse> RegisterAsync(PreRegisterDto preRegisterDto, CancellationToken cancellationToken)
    {
        var user = preRegisterDto.Adapt<UserEntity>();
        _repositoryManager.UserRepository.Insert(user);
        await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        user.Adapt<PreRegisterDto>();
        return new RegisterResponse();
    }
}

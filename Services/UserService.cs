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
    private readonly UserManager<UserEntity> _userManager;
    private readonly IEmailSender _emailSender;
    
    public UserService(IRepositoryManager repositoryManager, UserManager<UserEntity> userManager, IEmailSender emailSender)
    {
        _repositoryManager = repositoryManager;
        _userManager = userManager;
        _emailSender = emailSender;
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
        );
        if (user is null)
        {
            throw new UserNotFoundException(userId);
        }
        UserDto userDto = user.Adapt<UserDto>();
        return userDto;
    }

    public async Task<RegisterResponse> RegisterAsync(
        PreRegisterDto preRegisterDto,
        CancellationToken cancellationToken = default
    )
    {
        UserEntity user = new UserEntity
        {
            UserName = preRegisterDto.UserName,
            Email = preRegisterDto.Email,
            BirthDate = preRegisterDto.BirthDate,
        };

        var result = await _userManager.CreateAsync(user, preRegisterDto.Password)
            .ConfigureAwait(false);
        IdentityResultMessage(result);

        result = await _userManager.AddToRoleAsync(user, "User")
            .ConfigureAwait(false);
        IdentityResultMessage(result);
        
        var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
        var param = new Dictionary<string, string?>
        {
            {"token", token },
            {"id", user.Id},
        };
        
        if (preRegisterDto.ClientUri != null)
        {
            var callback = QueryHelpers.AddQueryString(preRegisterDto.ClientUri, param);
            
            var htmlButton = $"<a href='{callback}' style='background-color: #4CAF50; border: none; color: white; padding: 15px 32px; text-align: center; text-decoration: none; display: inline-block; font-size: 16px;'>Confirm User</a>";
            
            var message = new EmailMessage(new string[] { user.Email }, "Email Confirmation token", $"Click the next button to confirm your user registration: <br/> <br/> {htmlButton}", null);
            await _emailSender.SendEmailAsync(message);
        }

        return new RegisterResponse
        {
            IsSuccess = true,
            Message = "User created successfully",
            Id = user.Id,
            UserName = user.UserName,
            Email = user.Email,
        };
    } 

    public async Task UpdateAsync(Guid userId, UserForUpdateDto userForUpdateDto, CancellationToken cancellationToken = default)
    {
        UserEntity user = await _repositoryManager.UserRepository.GetByIdAsync(
            userId,
            cancellationToken
        );
        if (user is null)
        {
            throw new UserNotFoundException(userId);
        }
        user.FullName = userForUpdateDto.Name + " " + userForUpdateDto.LastName;
        user.CivilStatus = userForUpdateDto.CivilStatus.Adapt<CivilType>();
        user.BirthDate = userForUpdateDto.BirthDate;
        user.Address = userForUpdateDto.Address;
        user.City = userForUpdateDto.City;
        user.State = userForUpdateDto.State;
        user.UpdatedAt = DateTime.Now;
        
        await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
    }
    
    private void IdentityResultMessage(IdentityResult result)
    {
        if (!result.Succeeded)
        {
            var errors = result.Errors.Select(e => e.Description);
            throw new InvalidOperationException(string.Join(", ", errors));
        }
    }
}

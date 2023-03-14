using Contracts.Model;
using Contracts.Model.Security;
using Contracts.Model.Security.Response;

namespace Services.Abstractions;

public interface IUserService
{
    Task<IEnumerable<UsersResponse>> GetAllUserAsync(CancellationToken cancellationToken = default);
    Task<UsersResponse> GetUserByIdAsync(string userId, CancellationToken cancellationToken = default);
    Task UpdateAsync(string userId, UserForUpdateDto userForUpdateDto, CancellationToken cancellationToken = default);
    Task DeleteAsync(string userId, CancellationToken cancellationToken = default);
    Task UnlockUserAsync(string userId, string? username, CancellationToken cancellationToken);
    Task<UsersResponse> CreateAsync(UserForCreationDto userForCreationDto, string? username, CancellationToken cancellationToken = default);
}

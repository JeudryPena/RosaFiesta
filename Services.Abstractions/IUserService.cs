using Contracts.Model;
using Contracts.Model.Security;
using Contracts.Model.Security.Response;

namespace Services.Abstractions;

public interface IUserService
{
    Task<IEnumerable<UsersResponse>> GetAllUserAsync(CancellationToken cancellationToken = default);
    Task<UsersResponse> GetUserByIdAsync(Guid userId, CancellationToken cancellationToken = default);
    Task UpdateAsync(Guid userId, UserForUpdateDto userForUpdateDto, CancellationToken cancellationToken = default);
    Task DeleteAsync(Guid userId, CancellationToken cancellationToken = default);
}

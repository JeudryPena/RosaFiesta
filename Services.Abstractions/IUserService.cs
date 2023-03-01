using Contracts.Model;
using Contracts.Response;

namespace Services.Abstractions;

public interface IUserService
{
    Task<IEnumerable<UserDto>> GetAllUserAsync(CancellationToken cancellationToken = default);
    Task<UserDto> GetUserByIdAsync(Guid userId, CancellationToken cancellationToken = default);

    

    Task UpdateAsync(Guid userId, UserForUpdateDto userForUpdateDto, CancellationToken cancellationToken = default);
}

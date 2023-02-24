using Contracts;
using Contracts.Model;
using Contracts.Response;

namespace Services.Abstractions;

public interface IUserService
{
    Task<RegisterResponse> RegisterAsync(PreRegisterDto preRegisterDto, CancellationToken cancellationToken);
}

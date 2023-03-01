using Contracts.Model;
using Contracts.Model.Security;
using Contracts.Model.Security.Response;

namespace Services.Abstractions;

public interface IAuthenticateService
{
    Task<RegisterResponse> RegisterAsync(
        RegisterDto registerDto,
        CancellationToken cancellationToken = default
    );
    Task RegisterEmailAsync(string email);
    Task<FinishRegisterResponse> CreatePasswordAsync(FinishRegisterDto finishRegisterDto, string token, string id);
    Task ForgotPasswordAsync(string email);
    Task ResetPasswordAsync(ResetPasswordDto resetPasswordDto, string passwordToken, string id);
    Task ChangePasswordAsync(changePasswordDto changePasswordDto);
    Task LogoutAsync();
    Task<LoginResponse> LoginAsync(LogingDto logingDto);
    LoginResponse RefreshToken(TokenApiDto tokenApiDto);
    void RevokeToken(string username);
}
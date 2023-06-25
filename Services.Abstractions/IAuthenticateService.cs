using Contracts.Model.Security;
using Contracts.Model.Security.Response;

namespace Services.Abstractions;

public interface IAuthenticateService
{
	Task RegisterAsync(
		RegisterDto registerDto,
		CancellationToken cancellationToken = default
	);
	Task RegisterEmailAsync(string email);
	Task<FinishRegisterResponse> CreatePasswordAsync(FinishRegisterDto finishRegisterDto, string token, string id, CancellationToken cancellationToken = default);
	Task ForgotPasswordAsync(string email);
	Task ResetPasswordAsync(ResetPasswordDto resetPasswordDto, string passwordToken, string id, CancellationToken cancellationToken = default);
	Task ChangePasswordAsync(changePasswordDto changePasswordDto, CancellationToken cancellationToken = default);
	Task LogoutAsync();
	Task<LoginResponse> LoginAsync(LogingDto logingDto, CancellationToken cancellationToken = default);
	LoginResponse RefreshToken(TokenApiDto tokenApiDto);
	void RevokeToken(string username);
	Task<string> GetUserNameAsync(string userId);
}
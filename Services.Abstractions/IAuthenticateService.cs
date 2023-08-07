using Contracts.Model.Security;
using Contracts.Model.Security.Response;

namespace Services.Abstractions;

public interface IAuthenticateService
{
	Task RegisterAsync(
		RegisterDto registerDto,
		CancellationToken cancellationToken = default
	);
	Task ResendEmail(string email);
	Task ConfirmEmailAsync(string token, string email, CancellationToken cancellationToken);
	Task ForgotPasswordAsync(string email);
	Task ResetPasswordAsync(ResetPasswordDto resetPasswordDto, string passwordToken, string email, CancellationToken cancellationToken = default);
	Task ChangePasswordAsync(changePasswordDto changePasswordDto, CancellationToken cancellationToken = default);
	Task LogoutAsync();
	Task<LoginResponse> LoginAsync(LogingDto logingDto, CancellationToken cancellationToken = default);
	LoginResponse RefreshToken(TokenApiDto tokenApiDto);
	void RevokeToken(string username);
	Task<LoginResponse> VerifyGoogle(ExternalAuthDto externalAuth, string client);
}
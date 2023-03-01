namespace Contracts.Response;

public class RegisterResponse
{
    public string Id { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
    public bool IsSuccess { get; set; } = false;
    public string Email { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
}
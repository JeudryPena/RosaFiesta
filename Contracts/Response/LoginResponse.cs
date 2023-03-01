namespace Contracts.Response;

public class LoginResponse
{
    public bool IsAuthSuccessful { get; set; }
    public string? Expiration { get; set; }
    public int? Error { get; set; }
    public string? Token { get; set; }
    public string? Message { get; set; }
    public string? RefreshToken { get; set; }
}
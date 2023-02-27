namespace Contracts.Response;

public class RegisterResponse
{
    public string Id { get; set; }
    public string Message { get; set; }
    public bool IsSuccess { get; set; }
    public string? Email { get; set; }
    public string? UserName { get; set; }
}
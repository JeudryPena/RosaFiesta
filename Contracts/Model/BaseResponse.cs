namespace Contracts.Model;

public class BaseResponse
{
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
    public string? CreatedBy { get; set; } 
    public string? UpdatedBy { get; set; }
}
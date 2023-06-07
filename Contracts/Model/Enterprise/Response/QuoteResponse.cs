namespace Contracts.Model.Enterprise.Response;

public class QuoteResponse : BaseResponse
{
    public int Id { get; set; }
    public string CustomerName { get; set; }
    public string ContactNumber { get; set; }
    public string? ExtraInfo { get; set; }
    public string? Email { get; set; }
    public string EventName { get; set; }
    public DateTimeOffset EventDate { get; set; }
    public string Location { get; set; }
    public ICollection<QuoteItemResponse> QuoteItems { get; set; }
    public string? UserId { get; set; }
}
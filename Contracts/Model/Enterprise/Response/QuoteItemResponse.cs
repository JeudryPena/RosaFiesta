namespace Contracts.Model.Enterprise.Response;

public class QuoteItemResponse: BaseResponse
{
    public Guid Id { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public Guid QuoteId { get; set; }
    public Guid ServiceId { get; set; }
}
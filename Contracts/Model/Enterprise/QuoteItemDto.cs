namespace Contracts.Model.Enterprise;

public class QuoteItemDto
{
    public Guid Id { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public Guid ServiceId { get; set; }
}
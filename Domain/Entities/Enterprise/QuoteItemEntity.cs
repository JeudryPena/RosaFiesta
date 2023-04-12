namespace Domain.Entities.Enterprise;

public class QuoteItemEntity: BaseEntity
{
    public int Id { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public int QuoteId { get; set; }
    public Guid ServiceId { get; set; }
}
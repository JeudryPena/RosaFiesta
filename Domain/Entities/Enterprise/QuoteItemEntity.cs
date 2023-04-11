namespace Domain.Entities.Enterprise;

public class QuoteItemEntity
{
    public int Id { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public int QuoteId { get; set; }
    public int RentProductId { get; set; }
}
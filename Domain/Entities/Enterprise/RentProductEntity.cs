namespace Domain.Entities.Enterprise;

public class RentProductEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string Image { get; set; }
    public ICollection<QuoteItemEntity> QuoteItems { get; set; }
}
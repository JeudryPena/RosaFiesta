namespace Domain.Entities.Enterprise;

public class ServiceEntity: BaseEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string Image { get; set; }
    public ICollection<QuoteItemEntity> QuoteItems { get; set; }
    public int QuantityAvaliable { get; set; }
    public int Quantity { get; set; }
}
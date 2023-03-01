namespace Domain.Entities.Product;

public class WarrantyEntity: BaseEntity
{
    public string? Warranty { get; set; }
    public string? WarrantyType { get; set; }
    public string? WarrantyPeriod { get; set; }
    public string? WarrantyDescription { get; set; }
    public string? WarrantyConditions { get; set; }
    public string? WarrantyStatus { get; set; }
    public ICollection<ProductEntity>? Products { get; set; }
}
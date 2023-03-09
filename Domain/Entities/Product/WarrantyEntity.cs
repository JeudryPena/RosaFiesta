using Domain.Entities.Product.Helpers;

namespace Domain.Entities.Product;

public class WarrantyEntity: BaseEntity
{
    public Guid Id { get; set; }
    public string? Name { get; set; } 
    public WarrantyType Type { get; set; } = WarrantyType.Return;
    public WarrantyScopeType ScopeType { get; set; }
    public WarrantyStatusType? Status { get; set; }
    public string Period { get; set; } = "Period";
    public string Description { get; set; } = "Description";
    public string Conditions { get; set; } = "Conditions";
    public ICollection<ProductEntity>? Products { get; set; } 
}
namespace Domain.Entities.Product;

public class SupplierEntity: BaseEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public string? Email { get; set; } 
    public string? Phone { get; set; } 
    public string Address { get; set; } = String.Empty;
    public bool IsActive { get; set; }
    public ICollection<ProductEntity>? ProductsSupplied { get; set; }
}
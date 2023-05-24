using Domain.Entities.Product.Helpers;
using Domain.Entities.Product.UserInteract;

namespace Domain.Entities.Product;

public class ProductEntity : BaseEntity
{
    public string? Code { get; set; }
    public string Title { get; set; }
    public string? Brand { get; set; }
    public ProductType Type { get; set; }
    public int? CategoryId { get; set; }
    public CategoryEntity? Category { get; set; }
    public Guid? WarrantyId { get; set; }
    public WarrantyEntity? Warranty { get; set; }
    public ICollection<PurchaseDetailEntity>? Details { get; set; }
    public ICollection<ProductsDiscountsEntity>? Discounts { get; set; }
    public Guid? SupplierId { get; set; }
    public SupplierEntity? Supplier { get; set; }
    public IList<OptionEntity> Options { get; set; }
}

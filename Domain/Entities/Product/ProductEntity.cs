using System.ComponentModel.DataAnnotations;

using Domain.Entities.Product.UserInteract;

namespace Domain.Entities.Product;

public class ProductEntity : ByBaseEntity, IAutoBy
{
	public Guid Id { get; set; }
	[StringLength(500, MinimumLength = 3)]
	public string? Code { get; set; }
	public bool IsService { get; set; } = false;
	public int CategoryId { get; set; }
	public CategoryEntity Category { get; set; }
	public Guid? WarrantyId { get; set; }
	public WarrantyEntity? Warranty { get; set; }
	public ICollection<PurchaseDetailEntity>? Details { get; set; }
	public ICollection<ProductsDiscountsEntity>? Discounts { get; set; }
	public Guid? SupplierId { get; set; }
	public SupplierEntity? Supplier { get; set; }
	public IList<OptionEntity> Options { get; set; }
}

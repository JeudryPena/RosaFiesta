using System.ComponentModel.DataAnnotations;

using Domain.Entities.Product.UserInteract;

namespace Domain.Entities.Product;

public class ProductEntity : ByBaseEntity, IAutoBy
{
	public Guid Id { get; set; }
	[StringLength(500, MinimumLength = 3)]
	public string? Code { get; set; }
	[StringLength(100, MinimumLength = 3)]
	public string Name { get; set; }
	[StringLength(50, MinimumLength = 3)]
	public string? Brand { get; set; }
	public int CategoryId { get; set; }
	public CategoryEntity Category { get; set; }
	public int? SubCategoryId { get; set; }
	public SubCategoryEntity? SubCategory { get; set; }
	public Guid? WarrantyId { get; set; }
	public WarrantyEntity? Warranty { get; set; }
	public ICollection<PurchaseDetailEntity>? Details { get; set; }
	public ICollection<ProductsDiscountsEntity>? Discounts { get; set; }
	public Guid? SupplierId { get; set; }
	public SupplierEntity? Supplier { get; set; }
	public IList<OptionEntity> Options { get; set; }
}

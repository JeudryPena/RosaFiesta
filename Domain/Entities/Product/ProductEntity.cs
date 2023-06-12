using System.ComponentModel.DataAnnotations;

using Domain.Entities.Product.Helpers;
using Domain.Entities.Product.UserInteract;

namespace Domain.Entities.Product;

public class ProductEntity : BaseEntity
{
	[StringLength(100, MinimumLength = 3)]
	public string? Code { get; set; }
	[StringLength(100, MinimumLength = 5)]
	public string Title { get; set; }
	[StringLength(50, MinimumLength = 3)]
	public string? Brand { get; set; }
	[StringLength(15, MinimumLength = 4)]
	public ProductType Type { get; set; }
	public int CategoryId { get; set; }
	public CategoryEntity Category { get; set; }
	public int? SubCategoryId { get; set; }
	public Guid? WarrantyId { get; set; }
	public WarrantyEntity? Warranty { get; set; }
	public ICollection<PurchaseDetailEntity>? Details { get; set; }
	public ICollection<ProductsDiscountsEntity>? Discounts { get; set; }
	public Guid? SupplierId { get; set; }
	public SupplierEntity? Supplier { get; set; }
	public IList<OptionEntity> Options { get; set; }
}

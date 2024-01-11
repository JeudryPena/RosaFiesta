using System.ComponentModel.DataAnnotations;

using Domain.Entities.Product.UserInteract;

namespace Domain.Entities.Product;

public class ProductEntity : ByBaseEntity, IAutoBy
{
	public Guid Id { get; set; }
	[StringLength(500, MinimumLength = 3)]
	public string? Code { get; set; }
	public bool IsService { get; set; }
	public int CategoryId { get; set; }
	public int Views { get; set; }
	public CategoryEntity Category { get; set; }
	public Guid? WarrantyId { get; set; }
	public WarrantyEntity? Warranty { get; set; }
	public ICollection<PurchaseDetailEntity>? Details { get; set; }
	public Guid? SupplierId { get; set; }
	public SupplierEntity? Supplier { get; set; }
	public IList<OptionEntity> Options { get; set; }
	public OptionEntity? Option { get; set; }
	public Guid? OptionId { get; set; }
}

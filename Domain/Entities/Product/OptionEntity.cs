using System.ComponentModel.DataAnnotations;

using Domain.Entities.Product.Helpers;
using Domain.Entities.Product.UserInteract;

namespace Domain.Entities.Product;

public class OptionEntity : ISoftDelete
{
	public Guid Id { get; set; }
	[StringLength(100, MinimumLength = 3)]
	public string Title { get; set; }
	[StringLength(100, MinimumLength = 3)]
	public Guid ProductId { get; set; }
	[StringLength(1000, MinimumLength = 3)]
	public string? Description { get; set; }
	[Range(0.01, 999999.99)]
	public double Price { get; set; }
	public ICollection<MultipleOptionImagesEntity>? Images { get; set; }
	public MultipleOptionImagesEntity? Image { get; set; }
	public Guid? ImageId { get; set; }
	[Range(0, 1000)]
	public int QuantityAvailable { get; set; }
	[StringLength(100, MinimumLength = 3)]
	public string? Color { get; set; }
	public int? Quantity { get; set; }
	[StringLength(20, MinimumLength = 3)]
	public ConditionType Condition { get; set; }
	[StringLength(20, MinimumLength = 3)]
	public GenderType GenderFor { get; set; }
	public bool IsDeleted { get; set; }
	public ICollection<ReviewEntity>? Reviews { get; set; }
	public ICollection<ProductsDiscountsEntity>? ProductsDiscounts { get; set; }
	public ICollection<PurchaseDetailOptions>? PurchaseOptions { get; set; }
}
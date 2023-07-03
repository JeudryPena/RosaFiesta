using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Product;

public class SupplierEntity : ByBaseEntity, IAutoBy
{
	public Guid Id { get; set; }
	[StringLength(100, MinimumLength = 5)]
	public string Name { get; set; }
	[StringLength(1000, MinimumLength = 5)]
	public string? Description { get; set; }
	[StringLength(320, MinimumLength = 7)]
	public string? Email { get; set; }
	[StringLength(15, MinimumLength = 7)]
	public string? Phone { get; set; }
	[StringLength(200, MinimumLength = 5)]
	public string Address { get; set; }
	public ICollection<ProductEntity>? ProductsSupplied { get; set; }
}
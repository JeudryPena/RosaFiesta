using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Product;

public class CategoryEntity : BaseEntity
{
	public int Id { get; set; }
	[StringLength(50, MinimumLength = 3)]
	public string Name { get; set; }
	[StringLength(250, MinimumLength = 3)]
	public string Description { get; set; }
	[StringLength(200, MinimumLength = 3)]
	public string Icon { get; set; }
	public string CreatedBy { get; set; }
	public string? UpdatedBy { get; set; }
	public ICollection<SubCategoryEntity>? SubCategories { get; set; }
	public ICollection<ProductEntity>? Products { get; set; }
}
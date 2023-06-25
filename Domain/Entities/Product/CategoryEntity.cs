using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Product;

public class CategoryEntity : ByBaseEntity, IAutoBy
{
	public int Id { get; set; }
	[StringLength(50, MinimumLength = 3)]
	public string Name { get; set; }
	[StringLength(250, MinimumLength = 3)]
	public string Description { get; set; }
	[StringLength(200, MinimumLength = 3)]
	public string Icon { get; set; }
	public ICollection<SubCategoryEntity>? SubCategories { get; set; }
	public ICollection<ProductEntity>? Products { get; set; }
}
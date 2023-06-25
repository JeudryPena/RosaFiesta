using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Product;

public class SubCategoryEntity : ISoftDelete
{
	public int Id { get; set; }
	[StringLength(50, MinimumLength = 3)]
	public string Name { get; set; }
	[StringLength(250, MinimumLength = 3)]
	public string Description { get; set; }
	[StringLength(200, MinimumLength = 3)]
	public string Icon { get; set; }
	public bool IsDeleted { get; set; }
	public int CategoryId { get; set; }
	public ICollection<ProductEntity>? Products { get; set; }
}
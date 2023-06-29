using Contracts.Model.Product.UserInteract;

namespace Contracts.Model.Product;

public class OptionDto
{
	public string Title { get; set; }
	public string? Description { get; set; }
	public double Price { get; set; }
	public int QuantityAvailable { get; set; }
	public string? Color { get; set; }
	public float? Size { get; set; }
	public float Weight { get; set; }
	public int? GenderFor { get; set; }
	public int? Material { get; set; }
	public int Condition { get; set; }
	public ICollection<MultipleImageDto>? Images { get; set; }
}
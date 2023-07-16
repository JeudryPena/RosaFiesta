namespace Domain.Entities.Product;

public class MultipleOptionImagesEntity
{
	public Guid Id { get; set; } = Guid.NewGuid();
	public string Image { get; set; }
	public Guid OptionId { get; set; }
}
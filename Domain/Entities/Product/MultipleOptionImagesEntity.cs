namespace Domain.Entities.Product;

public class MultipleOptionImagesEntity
{
	public int Id { get; set; }
	public string Image { get; set; }
	public Guid OptionId { get; set; }
}
namespace Contracts.Model.Product.Response;

public class MultipleImagesResponse
{
	public Guid Id { get; set; }
	public string Image { get; set; }
	public Guid OptionId { get; set; }
}
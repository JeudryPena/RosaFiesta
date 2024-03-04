namespace Contracts.Model.Product.Response;
public class OptionCartResponse
{
	public string Title { get; set; }
	public string Description { get; set; }
	public MultipleImagesResponse Image { get; set; }
	public double Price { get; set; }
	public int QuantityAvailable { get; set; }
}

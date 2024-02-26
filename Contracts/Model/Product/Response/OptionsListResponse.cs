namespace Contracts.Model.Product.Response;
public class OptionsListResponse
{
	public Guid Id { get; set; }
	public string Title { get; set; }
	public Guid ProductId { get; set; }
	public int QuantityAvailable { get; set; }
}

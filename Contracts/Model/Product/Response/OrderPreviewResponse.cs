namespace Contracts.Model.Product.Response;

public class OrderPreviewResponse
{
	public Guid Id { get; set; }
	public DateTimeOffset OrderDate { get; set; }
}
namespace Contracts.Model.Product.Response;

public class OrderPreviewResponse
{
    public int SKU { get; set; }
    public DateTimeOffset OrderDate { get; set; }
    public string OrderStatus { get; set; }
}
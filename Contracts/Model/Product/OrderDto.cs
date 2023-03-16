namespace Contracts.Model.Product;

public class OrderDto
{
    public string ShippingAddress { get; set; }
    public string OrderAddress { get; set; }
    public string OrderPhone { get; set; }
    public string OrderEmail { get; set; }
    public int VoucherType { get; set; }
    public int VoucherNumber { get; set; }
    public string VoucherSeries { get; set; }
    public int OrderStatus { get; set; }
}
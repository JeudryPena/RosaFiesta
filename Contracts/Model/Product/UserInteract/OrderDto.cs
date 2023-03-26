namespace Contracts.Model.Product.UserInteract;

public class OrderDto
{
    public string ShippingAddress { get; set; }
    public string OrderAddress { get; set; }
    public string OrderPhone { get; set; }
    public string OrderEmail { get; set; }
    public int VoucherType { get; set; } = 1;
    public int VoucherNumber { get; set; } = 1;
    public string VoucherSeries { get; set; }
    public int OrderStatus { get; set; } = 1;
}
namespace Domain.Entities.Product.Helpers;

public enum OrderStatusType
{
    Pending = 1,
    Processing = 2,
    Shipped = 3,
    Delivered = 4,
    Cancelled = 5,
    Returned = 6,
    Refunded = 7,
    Paid = 8,
}
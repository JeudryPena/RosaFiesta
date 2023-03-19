namespace Domain.Entities.Product.Helpers;

public enum OrderStatusType
{
    Pending = 1,
    Processing = 2,
    Paid = 3,
    Cancelled = 4,
    Shipped = 5,
    Delivered = 6,
    Returned = 7,
    Refunded = 8,
}